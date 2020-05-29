let studioButton = document.getElementById("deleteStudioForm").addEventListener('submit', del);

function del(event) {
    event.preventDefault();

    var studioId = document.getElementById("DeleteStudio").value;

    alert("har kilckat");
    
    fetch(`/Api/StudiosApi/${studioId}`, {

    method: 'DELETE'

    });
};