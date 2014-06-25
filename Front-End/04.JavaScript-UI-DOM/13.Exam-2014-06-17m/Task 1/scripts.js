function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector);
    var leftBoxImage, rightBoxListItems, leftBoxTitle;

    var previewer = createPreviewer();
    container.appendChild(previewer);

    function createPreviewer() {
        var previewerBox = createPreviewerBox();
        createLeftBox(previewerBox);
        createRightBox(previewerBox);

        return previewerBox;
    }

    function createPreviewerBox() {
        // .previewer-container
        var previewerBox = document.createElement('div');
        previewerBox.style.width = '560px';
        previewerBox.style.height = '380px';
        previewerBox.style.borderRadius = '15px';
        previewerBox.style.boxShadow = '1px 1px 10px #cacaca';
        previewerBox.className = 'previewer-container';
        return previewerBox;
    }

    function createLeftBox(previewerBox) {
        // .previewer-leftBox
        var leftBox = document.createElement('div');
        leftBox.style.width = '70%';
        leftBox.style.height = '100%';
        leftBox.style.display = 'inline-block';
        leftBox.style.verticalAlign = 'top';
        leftBox.style.textAlign = 'center';
        leftBox.className = 'previewer-leftBox';
        previewerBox.appendChild(leftBox);

        // .previewer-leftBox-title
        leftBoxTitle = document.createElement('h1');
        leftBoxTitle.style.width = '100%';
        leftBoxTitle.style.marginTop = '7%';
        leftBoxTitle.innerHTML = items[0].title;
        leftBoxTitle.className = 'previewer-leftBox-title';
        leftBox.appendChild(leftBoxTitle);

        // .previewer-leftBox-image
        leftBoxImage = document.createElement('img');
        leftBoxImage.style.width = '90%';
        leftBoxImage.src = items[0].url;
        leftBoxImage.style.borderRadius = '15px';
        leftBoxImage.style.border = '1px solid #ddd';
        leftBoxImage.className = 'previewer-leftBox-image';
        leftBox.appendChild(leftBoxImage);
    }

    function createRightBox(previewerBox) {
        // .previewer-rightBox
        var rightBox = document.createElement('div');
        rightBox.style.width = '29%';
        rightBox.style.height = '93%';
        rightBox.style.marginTop = '2%';
        rightBox.style.display = 'inline-block';
        rightBox.style.textAlign = 'center';
        rightBox.style.overflowY = 'scroll';
        rightBox.className = 'previewer-rightBox';
        previewerBox.appendChild(rightBox);

        // .previewer-rightBox-filter-label
        var filterLabel = document.createElement('label');
        filterLabel.innerHTML = 'Filter';
        filterLabel.style.textAlign = 'center';
        filterLabel.style.display = 'block';
        filterLabel.style.marginTop = '0px';
        filterLabel.className = 'previewer-rightBox-filter-label';
        rightBox.appendChild(filterLabel);

        // .previewer-rightBox-filter
        var filter = document.createElement('input');
        filter.type = 'text';
        filter.style.width = '80%';
        addFilterEventHandlers(filter);
        filter.className = 'previewer-rightBox-filter';
        rightBox.appendChild(filter);

        // .previewer-rightBox-list
        rightBoxList = document.createElement('ul');
        rightBoxList.style.listStyleType = 'none';
        rightBoxList.style.padding = '0';
        rightBoxList.style.marginTop = '0';
        rightBoxList.className = 'previewer-rightBox-list';

        // templates
        var liTemplate = document.createElement('li');

        var imgTitleTemplate = document.createElement('h4');
        imgTitleTemplate.style.margin = '0';

        var imgTemplate = document.createElement('img');
        imgTemplate.style.width = '80%';
        imgTemplate.style.borderRadius = '5px';

        var li, img, imgTitle;
        for (var i = 0; i < items.length; i++) {
            // clone nodes
            li = liTemplate.cloneNode(true);
            img = imgTemplate.cloneNode(true);
            imgTitle = imgTitleTemplate.cloneNode(true);

            imgTitle.innerHTML = items[i].title;
            img.src = items[i].url;
            img.title = items[i].title;
            addImageEventHandlers(img);
            li.appendChild(imgTitle);
            li.appendChild(img);
            rightBoxList.appendChild(li);
        }
        rightBox.appendChild(rightBoxList);
        rightBoxListItems = rightBoxList.children;
        addFilterEventHandlers(filter);
    }

    function addFilterEventHandlers(filter) {
        filter.addEventListener('keyup', function () {
            var searchValue = this.value.toLowerCase();
            for (var i = 0, len = rightBoxListItems.length; i < len; i += 1) {
                var li = rightBoxListItems[i];
                var image = li.children[1];
                if (image.title.toLowerCase().indexOf(searchValue) > -1)
                    li.style.display = '';
                else
                    li.style.display = 'none';
            }
        });
    }

    function addImageEventHandlers(img) {
        img.addEventListener('click', function (evt) {
            leftBoxImage.src = this.src;
            leftBoxTitle.innerHTML = this.title;
        });

        img.addEventListener('mouseover', function (evt) {
            img.parentNode.style.background = 'rgb(202,202,202)';

        });

        img.addEventListener('mouseout', function (evt) {
            img.parentNode.style.background = '';
        });
    }
}