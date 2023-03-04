function enterCat(id) {

    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById('grid').innerHTML = this.responseText
        }
    };
    xhr.open('get', '/cat/index?handler=enterCatPartial&catid=' + id);
    xhr.send();
}

function chooseCatProperty(propid, propname) {

    document.getElementById('selcatname').value = propname;
    document.getElementById('selcatpropid').value = propid;

    //$('#staticBackdrop').modal('hide')
    bootstrap.Modal.getInstance(document.getElementById('staticBackdrop')).hide()
}


document.forms.newcatform.onsubmit = () => {

    let formData = new FormData(document.forms.newcatform);
    formData.append('catid', document.getElementById('catid-current').value);

    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('grid').innerHTML = this.responseText;
            document.forms.newcatform.reset();
        }
    };

    xhr.open('post', '/cat/index?handler=AddCat', true);
    xhr.send(new URLSearchParams(formData));
    return false;
};

document.forms.catproperty.onsubmit = () => {

    let formData = new FormData(document.forms.catproperty);
    formData.append('catid', document.getElementById('catid-current').value);

    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            document.getElementById('grid').innerHTML = this.responseText;
            document.forms.catproperty.reset();
        }
    };

    xhr.open('post', '/cat/index?handler=AddProperty', true);
    xhr.send(new URLSearchParams(formData));
    return false;
};