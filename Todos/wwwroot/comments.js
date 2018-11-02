document.addEventListener("DOMContentLoaded", (event) => {
    refreshComments();
    const saveComment = document.querySelector("#save-comment");
    saveComment.addEventListener("click", createComment);
});

function createComment() {
    const commentInput = document.querySelector("#new-comment");
    const newCommentText = commentInput.value;
    console.log('save!');
    console.log('id: ', todoId);
    console.log('comment: ', newCommentText);
    const newComment = {
        text: newCommentText,
        todoId: todoId
    };
    fetch('/api/comments', {
        method: 'POST',
        body: JSON.stringify(newComment),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(() => {
        commentInput.value = "";
        refreshComments();
    });
}

function refreshComments() {
    const ol = document.querySelector("#comment-list");
    ol.innerHTML = "";

    fetch(`/api/comments/${todoId}`)
        .then(res => res.json())
        .then(data => {
            data.forEach(c => addCommentToDom(c));
        });
}

function addCommentToDom(comment) {
    console.log(comment);
    const li = document.createElement('li');
    const date = new Date(comment.createdAt);
    li.innerHTML = `${comment.text} <div class="comment-date">${date.toDateString()}</div>`;
    const ol = document.querySelector("#comment-list");
    ol.appendChild(li);
}