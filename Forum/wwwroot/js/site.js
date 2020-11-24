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
