using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models.TestDoubles
{
    public class FakeDbSet<T> : IDbSet<T> where T : class
    {
        private readonly HashSet<T> _data;
        private readonly IQueryable _query;
        private IList<PropertyInfo> _KeyProperties { get; set; }

        private void AddKeyPropertyIfDoesntExist(PropertyInfo propertyInfo)
        {
            if (this._KeyProperties.Any(pi => (String.Compare(propertyInfo.Name, pi.Name, StringComparison.OrdinalIgnoreCase) == 0)) == false)
            {
                this._KeyProperties.Add(propertyInfo);
            }
        }

        /// <summary>
        /// Look at a type (and its metadata classes) looking for a property marked with [Key] attribute,
        /// or a property specifically named "Id" that is an integer
        /// </summary>
        private void GetKeyProperties()
        {
            this._KeyProperties = new List<PropertyInfo>();
            foreach (PropertyInfo prop1 in typeof(T).GetProperties())
            {
                if (prop1.GetCustomAttributes(true).OfType<KeyAttribute>().Any())
                {
                    this.AddKeyPropertyIfDoesntExist(prop1);
                }
            }

            //  check metadata classes
            MetadataTypeAttribute[] metaAttr = (MetadataTypeAttribute[])typeof(T).GetCustomAttributes(typeof(MetadataTypeAttribute), true);
            foreach (MetadataTypeAttribute attr in metaAttr)
            {
#pragma warning disable 168
                var t = attr.MetadataClassType;
#pragma warning restore 168
                foreach (PropertyInfo prop2 in typeof(T).GetProperties())
                {
                    //  If the property is named Id, we assume its the Key!
                    if ((String.Compare("Id", prop2.Name, StringComparison.OrdinalIgnoreCase) == 0) && (prop2.PropertyType == typeof(int)))
                    {
                        this.AddKeyPropertyIfDoesntExist(prop2);
                        break;
                    }

                    if (prop2.GetCustomAttributes(true).OfType<KeyAttribute>().Any() == true)
                    {
                        this.AddKeyPropertyIfDoesntExist(prop2);
                    }
                }
            }

            //  we didn't find any metadata answer, so lets fall back to looking for something named Id just on the class itself
            foreach (PropertyInfo prop3 in typeof(T).GetProperties())
            {
                //  If the property is named Id, we assume its the Key!
                if ((String.Compare("Id", prop3.Name, StringComparison.OrdinalIgnoreCase) == 0) && (prop3.PropertyType == typeof(int)))
                {
                    this.AddKeyPropertyIfDoesntExist(prop3);
                    break;
                }
            }
        }

        private void GenerateId(T entity)
        {
            //  dbset.Add() acts like this: Entities that are already in the context in some other state will have their state set to Added. Add is a no-op if the entity is already in the context in the Added state. 

            // If non-composite integer key
            if (this._KeyProperties.Count == 1 && this._KeyProperties[0].PropertyType == typeof(Int32))
            {
                var id = (Int32)this._KeyProperties[0].GetValue(entity);
                if (id == 0)
                {
                    Int32 maxpreviousidentity = 0;
                    if (this._data.Count > 0)
                    {
                        maxpreviousidentity = this._data.Max(en => (Int32)this._KeyProperties[0].GetValue(en));
                    }
                    this._KeyProperties[0].SetValue(entity, maxpreviousidentity + 1, null);
                }
            }
        }

        private int? GetIntegerIdentity(T entity)
        {
            if (this._KeyProperties.Count == 1 && this._KeyProperties[0].PropertyType == typeof(Int32))
            {
                var id = (Int32)this._KeyProperties[0].GetValue(entity);
                if (id > 0)
                {
                    return id;
                }
            }
            return null;
        }

        public FakeDbSet(IEnumerable<T> startData = null)
        {
            GetKeyProperties();
            _data = (startData != null ? new HashSet<T>(startData) : new HashSet<T>());
            _query = _data.AsQueryable();
        }

        public virtual T Find(params object[] keyValues)
        {
            if (keyValues.Length != this._KeyProperties.Count)
                throw new ArgumentException("Incorrect number of keys passed to find method");

            var keyQuery = this.AsQueryable();
            for (int i = 0; i < keyValues.Length; i++)
            {
                var x = i; // nested linq
                keyQuery = keyQuery.Where(entity => this._KeyProperties[x].GetValue(entity, null).Equals(keyValues[x]));
            }

            return keyQuery.SingleOrDefault();
        }

        public T Add(T item)
        {
            var id = this.GetIntegerIdentity(item);
            if (id > 0)
            {
                //  look to see if we already have the item (by its id value), and if so, remove the old one before adding this one, to simulate the replace which is how real DbSet would act
                var entity = this.Find(id);
                if (entity != null)
                {
                    this.Remove(entity);
                }
            }
            else
            {
                GenerateId(item);
            }
            _data.Add(item);
            return item;
        }

        public T Remove(T item)
        {
            _data.Remove(item);
            return item;
        }

        public T Attach(T item)
        {
            _data.Add(item);
            return item;
        }

        public void Detach(T item)
        {
            _data.Remove(item);
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _query.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public ObservableCollection<T> Local
        {
            get
            {
                return new ObservableCollection<T>(_data);
            }
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }
    }
}
