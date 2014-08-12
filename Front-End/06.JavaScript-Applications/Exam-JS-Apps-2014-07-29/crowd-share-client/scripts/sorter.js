define(["underscore"], function (_) {

    function sortPosts(posts, byProperty, ascending, numPosts) {
        if (byProperty)
            posts = _.sortBy(posts, byProperty);
        if (ascending)
            posts = posts.reverse();
        if (numPosts > 0)
            posts = _.take(posts, numPosts);
        return posts;
    }

    return {
        sortPosts: sortPosts
    }
});