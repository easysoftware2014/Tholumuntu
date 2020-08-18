$(function () {
    var dict = [];

    $("#wizard").steps({
        headerTag: "h4",
        bodyTag: "section",
        transitionEffect: "fade",
        enableAllSteps: true,
        transitionEffectSpeed: 300,
        labels: {
            next: "Continue",
            previous: "Back",
            finish: 'Submit your profile'
        },
        onStepChanging: function (event, currentIndex, newIndex) {
            
            if (newIndex >= 1) {
                $('.steps ul li:first-child a img').attr('src', '../../content/content/wizard/images/step-1.png');
            } else {
                $('.steps ul li:first-child a img')
                    .attr('src', '../../content/content/wizard/images/step-1-active.png');
            }

            if (newIndex === 1) {
                $('.steps ul li:nth-child(2) a img').attr('src', '../../content/wizard/images/step-2-active.png');
            } else {
                $('.steps ul li:nth-child(2) a img').attr('src', '../../content/wizard/images/step-2.png');
            }

            if (newIndex === 2) {
                $('.steps ul li:nth-child(3) a img').attr('src', '../../content/wizard/images/step-3-active.png');
            } else {
                $('.steps ul li:nth-child(3) a img').attr('src', '../../content/wizard/images/step-3.png');
            }

            //if (newIndex === 3) {
            //    $('.steps ul li:nth-child(4) a img').attr('src', '../../content/wizard/images/step-4-active.png');
            //    $('.actions ul').addClass('step-4');
            //} else {
            //    $('.steps ul li:nth-child(4) a img').attr('src', '../../content/content/wizard/images/step-4.png');
            //    $('.actions ul').removeClass('step-4');
            //}
            return true;
        },
        onFinished: function (event, currentIndex) {

            let ethnicity = $("input[name='ethnicity']:checked").val();
            let ethnicityId = $("#QuestionModel_Ethnicity_Id").val();
            createDictionary(ethnicityId, ethnicity);

            let belief = $("input[name='belief']:checked").val();
            let beliefId = $("#QuestionModel_WhatIsYourReligion_Id").val();
            createDictionary(beliefId, belief);
            
            let personalPreference = $("input[name='personal_preference']:checked").val();
            let preferenceId = $("#QuestionModel_PersonalPreference_Id").val();
            createDictionary(preferenceId, personalPreference);

            let valueMost = $("input[name='value_most']:checked").val();
            let valueMostId = $("#QuestionModel_ValueTheMost_Id").val();
            createDictionary(valueMostId, valueMost);

            let idealDate = $("input[name='idealdate']:checked").val();
            let idealDateId = $("#QuestionModel_IdealDate_Id").val();
            createDictionary(idealDateId, idealDate);

            let relationship = $("input[name='relationship']:checked").val();
            let relationshipId = $("#QuestionModel_DateSomeoneWithKids_Id").val();
            createDictionary(relationshipId, relationship);

            let different = $("input[name='different_belief']:checked").val();
            let differentId = $("#QuestionModel_DateDifferentBelief_Id").val();
            createDictionary(differentId, different);

            let ethnicGroup = $("input[name='ethnic_group']:checked").val();
            let ethnicGroupId = $("#QuestionModel_DateOutsideEthnicGroup_Id").val();
            createDictionary(ethnicGroupId, ethnicGroup);

            let feelLoved = $("input[name='feel_loved']:checked").val();
            let feelLovedId = $("#QuestionModel_IfeelLoveAndAppreciated_Id").val();
            createDictionary(feelLovedId, feelLoved);

            let word1 = $("input[name='word']:checked").val();
            let word1Id = $("#QuestionModel_WordDescribeYouBest_Id").val();
            createDictionary(word1Id, word1);

            let word2 = $("input[name='word1']:checked").val();
            let word2Id = $("#QuestionModel_WordDescribeYouBest2_Id").val();
            createDictionary(word2Id, word2);

            let word3 = $("input[name='word2']:checked").val();
            let word3Id = $("#QuestionModel_WordDescribeYouBest3_Id").val();
            createDictionary(word3Id, word3);

            let artistic = $("input[name='artistic']:checked").val();
            let artisticId = $("#QuestionModel_AreYouArtistic_Id").val();
            createDictionary(artisticId, artistic);

            let fate = $("input[name='fate']:checked").val();
            let fateId = $("#QuestionModel_DoYouBelieveInFate_Id").val();
            createDictionary(fateId, fate);

            let guiltyOf = $("input[name='guilty']:checked").val();
            let guiltyId = $("#QuestionModel_IamGuiltyOf_Id").val();
            createDictionary(guiltyId, guiltyOf);

            let occupation = $("input[name='occupation']:checked").val();
            let occupationId = $("#QuestionModel_Occupation_Id").val();
            createDictionary(occupationId, occupation);

            let prefer = $("input[name='prefer']:checked").val();
            let preferId = $("#QuestionModel_Iprefer_Id").val();
            createDictionary(preferId, prefer);
            
            let smoke = $("input[name='smoke']:checked").val();
            let smokeId = $("#QuestionModel_Smoke_Id").val();
            createDictionary(smokeId, smoke);

            let iam = $("input[name='iam']:checked").val();
            let iamId = $("#QuestionModel_Iam_Id").val();
            createDictionary(iamId, iam);

            let consider = $("input[name='consider']:checked").val();
            let considerId = $("#QuestionModel_IconsiderMyself_Id").val();
            createDictionary(considerId, consider);

            console.log(JSON.stringify(dict));
            var isUpdate = localStorage["IsUpdate"];
            
            var city = $("#txtCity").val();
            var state = $("#txtState").val();
            var personalInterest = $("#personal_interests").val();
            var describe_yourself = $("#describe_yourself").val();
            var describe_friends = $("#describe_friends").val();
            var favorite_quote = $("#favorite_quote").val();
            var choice = $("#choice").val();
            var horoscope = $("#drpHoroscope").val();
            var love_language = $("#love_language").val();
            var dateOfBirth = $("#dob").val();
            var gender = $("input[name='gender']:checked").val(); 

            var data = {
                "city": city,
                "state": state,
                "personalInterest": personalInterest,
                "describeYourself": describe_yourself,
                "howFriendsDescribeYou": describe_friends,
                "favoriteQuote": favorite_quote,
                "choice": choice,
                "horoscope": horoscope,
                "loveLanguage": love_language,
                "gender": gender,
                "dateOfBirth": dateOfBirth
            };

            var byteArray = localStorage["imgByteArray"];
            var imageType = localStorage["fileType"];

            if (isUpdate) {
                $.ajax({
                    type: "POST",
                    url: "updateanswers",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({ "answers": dict, "image": imageType, "bytearray": byteArray, "data" : data }),
                    dataType: "json",
                    success: function (data) {
                        event.preventDefault();
                        dict = [];
                        localStorage.clear();
                        alert("Profile Submitted for verification");
                    },
                    error: function (error) {
                        alert(error);
                    }
                });
            } else {
                $.ajax({
                    type: "POST",
                    url: "questionanswer/saveanswers",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({ "answers": dict, "image": imageType, "bytearray": byteArray, "data": data }),
                    dataType: "json",
                    cache: false,
                    success: function (data) {
                        event.preventDefault();
                        dict = [];
                        localStorage.clear();
                        alert("Profile Submitted for verification");
                    },
                    error: function (error) {
                        alert(error);
                    }
                });
            }

            
        }
    });
    function createDictionary(key, value) {
        dict.push({
            key: key,
            value: value
        });
    }

    function isEmpty(str) {
        return (!str || 0 === str.length);
    }

    var ethnicityVal = localStorage["ethnicity"];
    if(!isEmpty(ethnicityVal))
        setAnswers("ethnicity", ethnicityVal);

    var occupation = localStorage["occupation"];
    if (!isEmpty(occupation))
        setAnswers("occupation", occupation);

    var religion = localStorage["religion"];
    if (!isEmpty(religion))
        setAnswers("belief", religion);

    var word1 = localStorage["word1"];
    if (!isEmpty(word1))
        setAnswers("word", word1);

    var word2 = localStorage["word2"];
    if (!isEmpty(word2))
        setAnswers("word1", word2);

    var word3 = localStorage["word3"];
    if (!isEmpty(word3))
        setAnswers("word2", word3);

    var smoke = localStorage["smoke"];
    if (!isEmpty(smoke))
        setAnswers("smoke", smoke);

    var valueMost = localStorage["valuemost"];
    if (!isEmpty(valueMost))
        setAnswers("value_most", valueMost);

    var preference = localStorage["personal_preference"];
    if (!isEmpty(preference))
        setAnswers("personal_preference", preference);

    var iPrefer = localStorage["prefer"];
    if (!isEmpty(iPrefer))
        setAnswers("prefer", iPrefer);

    var loveAndAppreciated = localStorage["love"];
    if (!isEmpty(loveAndAppreciated))
        setAnswers("feel_loved", loveAndAppreciated);

    if (!isEmpty(localStorage["artistic"]))
        setAnswers("artistic", localStorage["artistic"]);

    if (!isEmpty(localStorage["date_different"]))
    setAnswers("different_belief", localStorage["date_different"]);

    if (!isEmpty(localStorage["fate"]))
    setAnswers("fate", localStorage["fate"]);

    if (!isEmpty(localStorage["ethnicGroup"]))
    setAnswers("ethnic_group", localStorage["ethnicGroup"]);

    if (!isEmpty(localStorage["withkids"]))
    setAnswers("relationship", localStorage["withkids"]);

    if (!isEmpty(localStorage["idealdate"]))
    setAnswers("idealdate", localStorage["idealdate"]);

    if (!isEmpty(localStorage["iam"]))
    setAnswers("iam", localStorage["iam"]);

    if (!isEmpty(localStorage["guilty"]))
        setAnswers("guilty", localStorage["guilty"]);

    if (!isEmpty(localStorage["Gender"]))
        setAnswers("gender", localStorage["Gender"]);

    if (!isEmpty(localStorage["consider"]))
    setAnswers("consider", localStorage["consider"]);

    if (!isEmpty(localStorage["State"]))
        $("#txtState").val(localStorage["State"]);
    
    if (!isEmpty(localStorage["PersonalInterest"]))
        $("#personal_interests").val(localStorage["PersonalInterest"]);

    if (!isEmpty(localStorage["FavoriteQuote"]))
        $("#favorite_quote").val(localStorage["FavoriteQuote"]);

    if (!isEmpty(localStorage["DescribeYourSelf"]))
        $("#describe_yourself").val(localStorage["DescribeYourSelf"]);

    if (!isEmpty(localStorage["HowFriendsDescribeYou"]))
        $("#describe_friends").val(localStorage["HowFriendsDescribeYou"]);

    if (!isEmpty(localStorage["Horoscope"]))
        $("#drpHoroscope").val(localStorage["Horoscope"]);

    if (!isEmpty(localStorage["LoveLanguage"]))
        $("#love_language").val(localStorage["LoveLanguage"]);

    if (!isEmpty(localStorage["DateOfBirth"]))
        $("#dob").val(localStorage["DateOfBirth"]);


    function setAnswers(name, value) {
        $("input[name=" + name + "][value=" + value + "]").prop('checked', true);
    }
    
    // Custom Button Jquery Steps
    $('.forward').click(function () {
        $("#wizard").steps('next');
    });
    $('.backward').click(function () {
        $("#wizard").steps('previous');
    });
    // Click to see password 
    $('.password i').click(function () {
        if ($('.password input').attr('type') === 'password') {
            $(this).next().attr('type', 'text');
        } else {
            $('.password input').attr('type', 'password');
        }
    });
    // Create Steps Image
    //$('.steps ul li:first-child')
    //    .append('<img src="../../content/wizard/images/step-arrow.png" alt="" class="step-arrow">').find('a')
    //    .append('<img src="../../content/wizard/images/step-1-active.png" alt=""> ')
    //    .append('<span class="step-order">Step 01</span>');
    //$('.steps ul li:nth-child(2')
    //    .append('<img src="../../content/wizard/images/step-arrow.png" alt="" class="step-arrow">').find('a')
    //    .append('<img src="../../content/wizard/images/step-2.png" alt="">')
    //    .append('<span class="step-order">Step 02</span>');
    //$('.steps ul li:nth-child(3)')
    //    .append('<img src="../../content/wizard/images/step-arrow.png" alt="" class="step-arrow">').find('a')
    //    .append('<img src="../../content/wizard/images/step-3.png" alt="">')
    //    .append('<span class="step-order">Step 03</span>');
    //$('.steps ul li:last-child a').append('<img src="../../content/wizard/images/step-4.png" alt="">')
    //    .append('<span class="step-order">Step 04</span>');
    // Count input 
    $(".quantity span").on("click",
        function () {

            var $button = $(this);
            var oldValue = $button.parent().find("input").val();

            if ($button.hasClass('plus')) {
                var newVal = parseFloat(oldValue) + 1;
            } else {
                // Don't allow decrementing below zero
                if (oldValue > 0) {
                    var newVal = parseFloat(oldValue) - 1;
                } else {
                    newVal = 0;
                }
            }
            $button.parent().find("input").val(newVal);
        });
    
});

