// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function searchArticles(str) {
    if (str.length == 0) {
        document.getElementById("searchResults").innerHTML = "";
        return;
    }
    else {
        var xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                document.getElementById("searchResults").innerHTML = this.responseText;
            }
        };


        xmlhttp.open("GET", "/Articles/Search/?searchString=" + str, true);
        xmlhttp.send();
    }
}