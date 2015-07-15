
function deleteAllDoneTasks(id) {
    $.ajax({
        url: 'api/tasks/removedone/' + id,
        type: 'DELETE',
        success: function () {
            $('#deleteDone').replaceWith("<div id='deleteDone'>Delete all done</div>");
        },
        error: function () {
            $('#deleteDone').replaceWith("<div id='deleteDone'>Don't delete</div>");
        }
    });
};
