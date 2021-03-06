﻿$(".selectpicker").select2({
    placeholder: "Select ailments",
    closeOnSelect: false
});

var ViewModel = function() {
    var self = this;
    self.ailments = ko.observableArray();
    self.selectedAilmentsId = ko.observableArray();
    self.error = ko.observable();

    var ailmentsUri = "/api/ailment/";

    function ajaxHelper(uri, method, data) {
        self.error("");
        return $.ajax({
            type: method,
            url: uri,
            dataType: "json",
            contentType: "application/json",
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXhr, textStatus, errorThrown) {
            self.error(JSON.stringify(jqXhr.responseText));
        });
    }

    function getAllAilments() {
        ajaxHelper(ailmentsUri, "GET")
            .done(function(data) {
                self.ailments(data);
            });
    }

    // fetch the initial data.
    getAllAilments();
}

ko.applyBindings(new ViewModel());
