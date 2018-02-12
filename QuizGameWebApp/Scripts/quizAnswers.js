$(document).ready(function () {
    var addAnswerButton = document.getElementById("add-answer-button"),
        answerDiv = document.getElementById("answer-div"),
        questionId = document.getElementById("QuestionId"),
        editNextAnswerId = document.getElementById("next-answer-id"),
        nextId = editNextAnswerId && editNextAnswerId.value ? editNextAnswerId.value : 0;

    //var panelTemplate = '<div class="form-group">' +
    //                      '<label class="control-label col-md-3" for="Answers[{{index}}].Id"> Id </label>' +
    //                      '<input type="text" class="form-control" name="Answers[{{index}}].Id" id="Answers[{{index}}].Id" value="{{index}}" />' +
    //                    '</div>' +

    var panelTemplate = '<div class="form-group">' +
                          '<input type="hidden" name="Answers[{{index}}].QuestionId" value="{{questionid}}"/>' +
                          '<label class="control-label col-md-3" for="Answers[{{index}}].Content">Content </label>' +
                          '<input type="text" class="form-control" name="Answers[{{index}}].Content" id="Answers[{{index}}].Content" />' +
                        '</div>' +

                        '<div class="form-group">' +
                          '<label class="control-label col-md-3" for="Answers[{{index}}].IsCorrect">Is Correct </label>' +
                          '<input type="checkbox" name="Answers[{{index}}].IsCorrect" id="Answers[{{index}}].IsCorrect" value="true" />' +
                          '<input type="hidden" name="Answers[{{index}}].IsCorrect" id="Answers[{{index}}].IsCorrect" value="false" />' +
                        '</div>';

    addAnswerButton.addEventListener("click", function () {
        var newAnswerHtml = panelTemplate.replace(/{{index}}/g, nextId++),
            newAnswerDiv = document.createElement("div"),
            newQuestionId = questionId.value ? questionId.value : "0",
            newAnswerHtml = newAnswerHtml.replace(/{{questionid}}/g, newQuestionId);
        newAnswerDiv.classList.add("panel");
        newAnswerDiv.innerHTML = newAnswerHtml;
        answerDiv.appendChild(newAnswerDiv);
    });

});









