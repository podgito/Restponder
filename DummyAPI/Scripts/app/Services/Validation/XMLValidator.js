/// <reference path="../../app.js" />
/// <reference path="../../../angular.js" />

//new
(function () {
    'use strict';

    var serviceId = 'xmlValidator';

    // TODO: replace app with your module name
    angular.module('DummyAPI').factory(serviceId, [XmlValidator]);

    function XmlValidator() {
        // Define the functions and properties to reveal.
        var service = {
            isValid: isValid
        };

        return service;

        function isValid(body) {
            var isValid = false;

            if (window.ActiveXObject) {
                var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
                xmlDoc.async = false;
                xmlDoc.loadXML(body);
                if (xmlDoc.parseError.errorCode == 0) {
                    isValid = true;
                }
            }
                // code for Mozilla, Firefox, Opera, etc.
            else if (document.implementation.createDocument) {
                try {
                    var parser = new DOMParser();
                    var xmlDoc = parser.parseFromString(body, "application/xml");
                }
                catch (err) {
                    isValid = false;
                }

                if (xmlDoc.getElementsByTagName("parsererror").length == 0) {
                    isValid = true;
                }
            }
            return isValid;
        }

        //#region Internal Methods        

        //#endregion
    }
})();

