'use strict';

app.factory('ArticlesResource', function($http, authorization, baseUrl) {
    var articlesApi = baseUrl + '/api/scores';

    return {
        create: function(article) {
            return $http.post(articlesApi, article, { headers: authorization.getAuthorizationHeader() });
        },
        getLatest: function(page, category) {
            if (page && category) {
                articlesApi += '?page=' + page + '&category=' + category
            }

            if (page) {
                articlesApi += '?page=' + page
            }

            if (category) {
                articlesApi += '?category=' + category
            }

            var auth = authorization.getAuthorizationHeader().Authorization;
            return $http({
                method: 'GET',
                url: articlesApi,
                dataType: 'jsonp',
                headers: authorization.getAuthorizationHeader()
             });
            //return $http.get(articlesApi, config);
        },
        getById: function(id) {
            return $http.get(articlesApi + '/' + id)
        },
        addComment: function(id, comment) {
            return $http.post(articlesApi + '/' + id + '/comments');
        },
        getComments: function(id, page) {
            return $http.get(articlesApi + '/' + id + '/comments?page=' + page);
        }
    }
});