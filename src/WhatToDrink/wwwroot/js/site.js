// Write your Javascript code.
$(document).ready(function () {
    console.log('ready')

 /*   $("#Beer_SeasonId").on("change", function (e) {
        $.ajax({
            url: `/Beer/GetFeelings/`,
            method: "POST",
            dataType: "json",
            contentType: 'application/json; charset=utf-8'
        }).done((feelings) => {
            $("#Beer_FeelingId").html("");
            $("#Beer_FeelingId").append("<option value=null> How are you feeling? </option>");
            feelings.forEach((option) => {
                console.log("these are the options", option);
                $("#Beer_FeelingId").append(`<option value="${option.FeelingId}">${option.description}</option>`)
            });
        });
    });*/

    $("#Beer_SeasonId").on("change", function (e) {
        console.log('SeasonId clicked')
        $.ajax({
            url: `/Beer/GetBeersBySeason/${$(this).val()}`,
            method: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        }).done((beersBySeason) => {
            $("#BeersGoHere").html("");
            beersBySeason.forEach((beer) => {
                console.log("these are the beers", beer);
                $("#BeersGoHere").append(`<h3>${beer.name}</h3>`)
            });
        });
    });

    $("#Beer_FeelingId").on("change", function (e) {
        console.log('FeelingId clicked')
        $.ajax({
            url: `/Beer/GetBeersByFeelings/${$(this).val()}`,
            method: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        }).done((beersBySeason) => {
            $("#BeersByFeelingGoHere").html("");
            beersBySeason.forEach((beer) => {
                console.log("these are the beers", beer);
                $("#BeersByFeelingGoHere").append(`<h3>${beer.name}</h3>`)
            });
        });
    });


    $("#Beer_DayId").on("change", function (e) {
        console.log('DayId clicked')
        $.ajax({
            url: `/Beer/GetBeersByDay/${$(this).val()}`,
            method: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        }).done((beersByDay) => {
            $("#BeersByDayGoHere").html("");
            beersByDay.forEach((beer) => {
                console.log("these are the beers", beer);
                $("#BeersByDayGoHere").append(`<h3>${beer.name}</h3>`)
            });
        });
    });
});


