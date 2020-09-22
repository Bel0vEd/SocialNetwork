function viewRes(id) {
    if (document.getElementById("responce " + id).style.display == "block")
        document.getElementById("responce " + id).style.display = "none";
    else
        document.getElementById("responce " + id).style.display = "block"
};