var ModalDialog = (function () {
    function showMessage(headerMsg, bodyMsg) {
        $('#myModalLabel').html(headerMsg);
        $('#myModalLabeBody').html(bodyMsg);
        $('#restricted-access-modal').modal('show');
    }

    return {
        show: showMessage
    }
}());