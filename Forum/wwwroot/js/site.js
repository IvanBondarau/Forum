// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function AddLabel() {
    let labelName = document.getElementById('label-name-input').value;
    let label = document.createElement('div')
    label.classList.add('uk-label')
    label.classList.add('uk-margin-small-bottom')
    label.classList.add('uk-margin-small-right')
    let content = document.createTextNode(labelName);
    label.appendChild(content);
    document.getElementById("labels-list").appendChild(label)
    let previousInput = document.getElementsByClassName('labels-input')[0].value
    if (previousInput == '') {
        document.getElementsByClassName('labels-input')[0].value = labelName
    } else {
        document.getElementsByClassName('labels-input')[0].value = previousInput + ";" + labelName
    }
}

function SendImage() {
    var formData = new FormData();

    // add assoc key values, this will be posts values
    formData.append("file", this.file, this.getName());
    formData.append("upload_file", true);

    $.ajax({
        type: "POST",
        url: "script",
        xhr: function () {
            var myXhr = $.ajaxSettings.xhr();
            if (myXhr.upload) {
                myXhr.upload.addEventListener('progress', that.progressHandling, false);
            }
            return myXhr;
        },
        success: function (data) {
            // your callback here
        },
        error: function (error) {
            // handle error
        },
        async: true,
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        timeout: 60000
    });
}

function LikeMessage(messageId) {
    

    $.ajax({
        type: 'POST',
        url: '/Message/Like/' + messageId,
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        complete: function (result) {
            alert(result);
        },  

    })
}

function DeleteMessage(messageId) {
    

    $.ajax({
        type: 'DELETE',
        url: '/Message/Delete/' + messageId,
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        complete: function (result) {
            location.reload()
        },
        

    })
}

