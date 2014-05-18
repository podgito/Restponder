/// <reference path="../../app.js" />
/// <reference path="../../../angular.js" />

'use strict';

app.factory('xmlValidator', function () {
    return {
        isValid: function (body) {

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
    };
});
