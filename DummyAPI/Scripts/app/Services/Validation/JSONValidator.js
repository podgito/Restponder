/// <reference path="../../app.js" />
/// <reference path="../../../angular.js" />


'use strict';

app.factory('jsonValidator', function () {
    return {
        isValid : function(body)
        {
            

            try {
                jQuery.parseJSON(body);
            } catch (e) {
                return false;
            }
            return true;
        }
    };
});