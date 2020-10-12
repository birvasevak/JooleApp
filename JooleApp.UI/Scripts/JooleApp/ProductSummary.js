$(document).ready(()=>{

    console.log("here");
    $(".slider").on('change', (e) => {
        const sliderItemId = e.target.id;

    });


    $("#search").on('click', (e) => {
        var sliderValue = {};
        $(".slider").each((pos, obj) => {
            let name = "#" + obj.id
            if (name != "#") {
                sliderValue[obj.id] = $(name).val();
            }
        });

    });



});