// Write your Javascript code.
$(document).ready(function () {
    console.log('ready')



    $("#Beer_SeasonId").on("change", function (e) {
        var x = $(this).val();
        console.log(x, "this is x");
        $("#Beer_FeelingId").on("change", function (e) {
            var y = $(this).val();
            console.log(y, "this is y");
            $("#Beer_DayId").on("change", function (e) {
                var z = $(this).val();
                console.log(z, "this is z");
                $.ajax({
                    url: `/Beer/GetBeersByAll/${x}/${y}/${z}`,
                    method: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8"
                }).done((beersByAll) => {
                    console.log("i am a banana");
                     $("#AllBeersGoHere").html("");
                     beersByAll.forEach((beer) => {
                         console.log("these are the beers", beer);
                         $("#AllBeersGoHere").append(`<h3>${beer.name}</h3>`)
                     });
                 });
            });
        });
    });

    $("#Beer_Season").on("change", function (e) {
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
                $("#BeersGoHere").append(`<div class="col-sm-6"><img class="card-img-top" src=${beer.imgUrl}><h3>${beer.name}</h3><p>${beer.brewery}</p></div>`)
            });
        });
    });


    $("#Beer_Feeling").on("change", function (e) {
        console.log('FeelingId clicked')
        $.ajax({
            url: `/Beer/GetBeersByFeelings/${$(this).val()}`,
            method: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        }).done((beersByFeeling) => {
            $("#BeersByFeelingGoHere").html("");
            beersByFeeling.forEach((beer) => {
                console.log("these are the beers", beer);
                $("#BeersByFeelingGoHere").append(`<div class="col-sm-6"><img class="card-img-top" src=${beer.imgUrl}><h3>${beer.name}</h3><p>${beer.brewery}</p></div>`)
            });
        });
    });


    $("#Beer_Day").on("change", function (e) {
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
                $("#BeersByDayGoHere").append(`<div class="col-sm-6"><img class="card-img-top" src=${beer.imgUrl}><h3>${beer.name}</h3><p>${beer.brewery}</p></div>`)
            });
        });
    });
});


