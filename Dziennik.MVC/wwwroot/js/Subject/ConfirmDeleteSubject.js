function confirmDelete(subjectId) {
    var result = confirm('Are you sure you want to delete this subject?');
    if (result) {
        window.location.href = '/Subject/Delete/' + subjectId;
    }
    return false;
}