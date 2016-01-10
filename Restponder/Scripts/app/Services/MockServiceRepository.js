(function () {
    'use strict';

    var serviceId = 'mockServiceRepository';

    // TODO: replace app with your module name
    angular.module('DummyAPI').factory(serviceId,  ['$rootScope', '$q', MockServiceRepository]);

    function MockServiceRepository($rootScope, $q) {
        // Define the functions and properties to reveal.
        var repoService = {
            services: [],
            addService: addService,
            getServices: getServices,
            deleteService: deleteService
        };

        var db = openDatabase('mockServices', '1.0', 'Mock Services', 10 * 1024);

        db.transaction(function (tx) {
            //tx.executeSql('DROP TABLE IF EXISTS services');
            tx.executeSql('CREATE TABLE IF NOT EXISTS services (id unique, name, url, editUrl)');
        });

        return repoService;

        function addService(service) {
            db.transaction(function (tx) {
                tx.executeSql('INSERT INTO services (id, name, url, editUrl) VALUES (?, ?, ?, ?)', [service.key, service.name, service.url, service.editUrl]);
                console.log('saved');
            });
        }

        function getServices() {

            db.transaction(function (tx) {
                
                tx.executeSql('SELECT * FROM services', [], function (tx, results) {
                    var len = results.rows.length, i;
                    console.log(len);
                    for (i = 0; i < len; i++) {
                        console.log('item');
                        $rootScope.$apply(function () {
                            var service = new Object();
                            service.key = results.rows.item(i).id;
                            service.name = results.rows.item(i).name;
                            service.url = results.rows.item(i).url;
                            service.editUrl = results.rows.item(i).editUrl;

                            repoService.services.push(service);
                        });

                    }
                });
            });
        }

        function deleteService(service){

        }

        //#region Internal Methods        

        //#endregion
    }
})();