$(document).ready(function() {
    $('a.delete').click(function(){
        $.ajax(
            {
                url: this.getAttribute('href'),
                type: 'DELETE',
                async: false,
                complete: function(response, status) {
                    if (status == 'success') {
                        //alert('Success: the service responded with: ' + response.status + '\n' + response.responseText)
                        window.location.reload();
                    }
                    else {
                        alert('Error: the service responded with: ' + response.status + '\n' + response.responseText)
                    }
                }
            }
        )
        return false
    });
    
    $('a.update').click(function(){
        $.ajax(
            {
                url: this.getAttribute('href'),
                type: 'POST',
                async: false,
                complete: function(response, status) {
                    if (status == 'success') {
                        //alert('Success: the service responded with: ' + response.status + '\n' + response.responseText)
                        window.location.reload();
                    }
                    else {
                        alert('Error: the service responded with: ' + response.status + '\n' + response.responseText)
                    }
                }
            }
        )
        return false
    })
});
