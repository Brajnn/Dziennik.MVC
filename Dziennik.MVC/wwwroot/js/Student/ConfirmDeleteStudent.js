function confirmDelete(studentId) {
    var result = confirm('Are you sure you want to delete this student??');
    if (result) {
        window.location.href = '/Student/Delete/' + studentId;
    }
    return false;
}