$(document).ready(function() {
           $('#input-initiative').hide(); 
            $('#input-season').hide(); 
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
    });
    
    $('#type').change(function(){
        
        //  'initiative-based', 'initiative-and-season-based'
        var type = $(this).val();
        if(type == 'public') {
           $('#input-initiative').hide(); 
            $('#input-season').hide(); 
        } 
        
        if(type == 'initiative-based') {
            $('#input-initiative').show(); 
            $('#input-season').hide(); 
        } 
        
        if(type == 'initiative-and-season-based') {
            $('#input-initiative').show(); 
            $('#input-season').show(); 
        } 
    });

});
