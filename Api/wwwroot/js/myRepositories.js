function handleRepositoryNameInput() {
    var inputText = document.getElementById("repositoryNameInput").value.toLowerCase();
    var repoItems = document.querySelectorAll(".repo-item");

    repoItems.forEach(function (repoItem) {
        var repoName = repoItem.getAttribute("data-repo-name").toLowerCase();
        if (repoName.includes(inputText)) {
            repoItem.style.display = "flex";
        } else {
            repoItem.style.display = "none";
        }
    });
}