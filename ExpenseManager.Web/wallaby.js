module.exports = function (wallaby) {
    return {
        files: [
        {
            pattern: "Scripts/sinon-1.9.1.js",
            instrument: false
        },
        {
            pattern: "JS/lib/bower_components/angular/angular.js",
            instrument: false
        },
        {
            pattern: "JS/lib/bower_components/angular-mocks/angular-mocks.js",
            instrument: false
        },
        {
            pattern: "JS/lib/bower_components/angular-ui-router/release/angular-ui-router.js",
            instrument: false
        },
        {
            pattern: "JS/lib/bower_components/Chart.js/Chart.js",
            load: true,
            ignore: false
        },
        {
            pattern: "JS/lib/bower_components/angular-chart.js/angular-chart.js",
            load: true,
            ignore: false
        },        
        {
            pattern: "JS/Tests/**/mock*.js",
            instrument: false
        },
        {
            pattern: "app/em.module.js",
            instrument: false
        },
        {
            pattern: "app/expenseSummary/expenseSummary.module.js",
            load: true,
            ignore: false
        },
        {
            pattern: 'app/app.js',
            load: true,
            ignore: false
        },
        {
            pattern: 'app/utils/utils.module.js',
            load: true,
            ignore: false
        },
        {
            pattern: 'app/em.module.js',
            load: true,
            ignore: false
        },
         'app/*.js',
         'app/*/*.js',
         'app/*/*/*.js',
         'app/*/*/*/*.js',
         'app/*/*/*/*/*.js',
         'JS/Tests/**/*.service.js'
        ],

        tests: [
          'JS/Tests/*.spec.js',
          'JS/Tests/**/*.spec.js'
        ],
        testFramework: 'jasmine',
        debug: true
    };
};