$.fn.gallery = function (cols) {
    var $gallery = this;
    $gallery.addClass('gallery');
    $gallery.find('.selected').hide();
    var isSelected = false;
    var imagesCount = $gallery.find('.image-container').length;
    var indexCurrent = 1;

    var $selectedImages = $gallery.find('.selected');
    var $galleryList = $gallery.find('.gallery-list');

    var imageContainerWidth = $gallery.find('.image-container').outerWidth(true) + 1;
    $gallery.width(imageContainerWidth * (cols || 4));

    $gallery.click(function (evt) {
        var target = evt.target;

        if (!(evt.target instanceof HTMLImageElement))
            return;

        $clicked = $(evt.target);

        if (isSelected) {

            if ($clicked.is("#current-image")) {
                isSelected = false;
                $selectedImages.hide();
                $galleryList.toggleClass('blurred');
            } else if ($clicked.is("#previous-image")) {
                indexCurrent = (indexCurrent - 2 + imagesCount) % (imagesCount) + 1;
                selectImages(indexCurrent);

            } else if ($clicked.is("#next-image")) {
                indexCurrent = indexCurrent % imagesCount + 1;
                selectImages(indexCurrent);
            }
        } else {
            isSelected = true;
            indexCurrent = +$clicked.attr('data-info');
            selectImages(indexCurrent);
            $selectedImages.show();
            $galleryList.toggleClass('blurred');
        }
    });

    function selectImages(indexCurrent) {
        var indexNext = indexCurrent % imagesCount + 1;
        var indexPrev = (indexCurrent - 2 + imagesCount) % (imagesCount) + 1;

        var nextSrc = $galleryList.find("img[data-info='" + indexNext + "']").attr('src');
        var srcCurrent = $clicked.attr('src');
        var prevSrc = $galleryList.find("img[data-info='" + indexPrev + "']").attr('src');

        $selectedImages.find('#previous-image').attr('src', prevSrc);
        $selectedImages.find('#current-image').attr('src', srcCurrent);
        $selectedImages.find('#next-image').attr('src', nextSrc);
    }
};