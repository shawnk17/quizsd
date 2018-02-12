$(document).ready(function () {
    var getQuestionButton = document.getElementById("get-question-button"),
        questionDisplayBox = document.getElementById("question-display"),
        currentQuestionId;

    var clickHandler = function clickHandler(event) {
        var answerSubmission = {
            questionId: currentQuestionId,
            answerId: event.currentTarget.id   
        };
        //alert(anwserSubmission.questionId + " " + anwserSubmission.answerId);
        $.getJSON("/api/quizquestion/isanswercorrect/", answerSubmission)
            .done(function (data) {  
                if (data.IsCorrect) {
                    var ans
                    //document.getElementById("answer-result").innerHTML = "Right: Yeah! You got it.";
                    document.getElementById("answer-result").innerHTML = 
                        '<div class="panel panel-primary">' +
                           '<div class="panel-heading">' +
                               'Right' +
                           '</div>' +
                           '<div class="panel-body right-answer">' + 
                               'Yeah! You got it.'+
                           '</div>' +
                         '</div>';                                                                
                     // document.getElementById("answer-result").classList.add("panel panel-primary");

                    
                } else {
                    //document.getElementById("answer-result").innerHTML = "Wrong: Sorry, you're a loser.";
                    document.getElementById("answer-result").innerHTML =
                        '<div class="panel panel-danger">' +
                          '<div class="panel-heading">' +
                              'Wrong' +
                          '</div>' +
                          '<div class="panel-body wrong-answer">' +
                              'Sorry, you are a loser.' +
                          '</div>' +
                        '</div>';
                    //document.getElementById("answer-result").classList.add("panel panel-body");
                }
            })
            .fail(function (jqxhr, textStatus, error) {  
                alert("Whoops! Something is not right"); 
            })
    }
        
    getQuestionButton.addEventListener("click", function () {
        $.getJSON('/api/quizquestion', function (data) {
            var newQuestionDiv = document.createElement('div');

            questionDisplayBox.innerHTML = "";
            currentQuestionId = data.QuestionId;
            //newQuestionDiv.id = data.QuestionId; //don't need it.

            questionDisplayBox.appendChild(newQuestionDiv);
            newQuestionDiv.innerText = data.Content;
            

            data.Answers.forEach(function (val) {
                var answerDiv = document.createElement('div');

                answerDiv.innerText = val.Content;
                answerDiv.id = val.AnswerId;
                answerDiv.addEventListener('click', clickHandler);
                questionDisplayBox.appendChild(answerDiv);
                answerDiv.className = 'answerBox';
                answerDiv.addEventListener("mouseenter", function (event) {
                    event.target.style.color = "green";
                });
                answerDiv.addEventListener("mouseout", function (event) {
                    event.target.style.color = "black";
                });

              
                questionDisplayBox.className = 'questionText';
           });
        });
     });
});