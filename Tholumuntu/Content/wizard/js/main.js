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

            let occupation = $("input[name='occupation']:checked").val();
            let occupationId = $("#QuestionModel_Occupation_Id").val();

            let prefer = $("input[name='prefer']:checked").val();
            let preferId = $("#QuestionModel_Iprefer_Id").val();

            let smoke = $("input[name='smoke']:checked").val();
            let smokeId = $("#QuestionModel_Smoke_Id").val();

            let iam = $("input[name='iam']:checked").val();
            let iamId = $("#QuestionModel_Iam_Id").val();

            let consider = $("input[name='consider']:checked").val();
            let considerId = $("#QuestionModel_IconsiderMyself_Id").val();

            let ethnicity = $("input[name='ethnicity']:checked").val();
            let ethnicityId = $("#QuestionModel_Ethnicity_Id").val();
            createDictionary(ethnicityId, ethnicity);

            let belief = $("input[name='guilty']:checked").val();
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

            let word2 = $("input[name='word2']:checked").val();
            let word2Id = $("#QuestionModel_WordDescribeYouBest2_Id").val();
            createDictionary(word2Id, word2);

            let word3 = $("input[name='word3']:checked").val();
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
            createDictionary(considerId, consider);
            createDictionary(iamId, iam);
            createDictionary(smokeId, smoke);
            createDictionary(preferId, prefer);
            createDictionary(guiltyId, guiltyOf);
            createDictionary(occupationId, occupation);

            $.ajax({
                type: "POST",
                url: "questionanswer/saveanswers",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(dict),
                dataType: "json",
                cache: false,
                success: function (data) {
                    event.preventDefault();
                    alert("Profile Submitted for verification");

                },
                error: function (error) {
                    alert(error);
                }
            });
        }
    });
    function createDictionary(key, value) {
        dict.push({
            key: key,
            value: value
        });
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
