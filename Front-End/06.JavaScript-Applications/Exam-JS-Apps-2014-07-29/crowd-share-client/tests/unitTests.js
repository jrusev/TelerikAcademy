define(['chai', '../scripts/sorter'], function (chai, sorter) {
    var assert = chai.assert;

    describe('Testing sorter module', function () {
        it('when sorting empty array of posts, expect sorter to return empty array', function () {
            var posts = [];
            // function sortPosts(posts, byProperty, ascending, numPosts)
            var sorted = sorter.sortPosts(posts, 'postDate', false, 20);
            assert.equal(0, sorted.length);
        });
    })

});