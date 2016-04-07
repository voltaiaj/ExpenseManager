describe('expenseSummaryController', function() {
    var actual,
        $controller,
        expenseManagerDataService,
        $rootScope,
        $httpBackend;        

    beforeEach(function() {
        module('em.expenseSummary');
        module('em');
        module('chart.js');

        inject(function(_$controller_, _$rootScope_,_expenseManagerDataService_, _$httpBackend_) {
            $controller = _$controller_;
            expenseManagerDataService = _expenseManagerDataService_;
            $rootScope = _$rootScope_.$new();
            $httpBackend = _$httpBackend_;
        });

        actual = $controller('expenseSummaryController');
        $httpBackend.expect('GET', 'api/Expense/GetCurrentMonthSummary').respond(200, {});
        $httpBackend.expect('GET', '/app/home/homeIndex.html').respond(200, {});

        $rootScope.$apply();
    });

    it('should be created successfully', function() {
        expect(actual).toBeDefined();
    });


});