define(['chai', '../scripts/storage'], function (chai, storage) {
    var assert = chai.assert;

    describe('Testing storage module', function () {
        it('when setting user name, expect storage to return that name', function () {
            storage.setUsername('testUser');
            assert.equal('testUser', storage.getUsername());
        });
        it('when name is cleared from the storage, it should return null', function () {
            storage.setUsername('testUser');
            storage.clearUsername();
            assert.equal(null, storage.getUsername());
        });
    })

});