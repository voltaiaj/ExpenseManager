using System.Collections.Generic;

namespace ExpenseManager.Business.BusinessLogic
{
    public class Classifier
    {
        /// <summary>
        /// Method takes in expenses determines which of the categories expense should be classified as
        /// </summary>
        /// <param name="expenses"></param>
        /// <returns></returns>
        public IEnumerable<string[]> Classfy(IEnumerable<string[]> expenses)
        {
            
            /*retrieves all of the the trainingset entries and 
             * searches on the their keyword entries and when 90% match is found it is catagorized
             * */
            return null;
        }
    }
}
