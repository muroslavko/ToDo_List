//$(document).ready(
//    alert("hello")
//);
//$(function () {
//    $('#editLink').click(function (taskId) {
//        alert("hello1");
//        var a = taskId;
//        alert(a);
//        $.ajax({
//            url: 'api/tasks/all',
//            type: 'GET',
//            success: function () {
//                alert("hello2");
//            },
//            error: function () {
//                alert("hello3");
//            }
//        });
//    });
//});

function editTask(taskId) {
    alert("hello1");
    var a = taskId;
    alert(a);
    $.ajax({
        url: 'api/tasks/all',
        type: 'GET',
        success: function () {
            alert("hello2");
        },
        error: function () {
            alert("hello3");
        }
    });
};