jQuery(document).ready(function($) {

    $('a[data-ail]').mousedown(function(event) {

        var link_type = 'ail';
        
        //save the click with an ajax request
        track_link(link_type, $(this));
        
    });
    
    $('a[data-mil]').mousedown(function(event) {
        
        var link_type = 'mil';
        
        //save the click with an ajax request
        track_link(link_type, $(this));
        
    });
    
    //track the link with an ajax request
    function track_link(link_type, caller_element){
        
        //set source
        var source_post_id = caller_element.attr('data-' + link_type);

        //set target
        var target_url = caller_element.attr('href');
        
        //prepare ajax request
        var data = {
            "action": "track_internal_link",
            "security": dagp_nonce,
            "link_type": link_type,
            "source_post_id": source_post_id,
            "target_url": target_url
        };

        //send the ajax request
        $.post(dagp_ajax_url, data, function(data) {});
        
    }

});