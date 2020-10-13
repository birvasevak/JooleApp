
$(document).ready(()=>{

    console.log("here");
    $(".slider").on('change', (e) => {
        const sliderItemId = e.target.id;

    });


    $(".searchButton").on('click', (e) => {
        var sliderValue = {
            "data": {}};
        $(".sliderInside").each((pos, obj) => {
            let name = "#" + obj.id

            if (name != "#") {
                let tempMin = "#minVal_" + obj.id;
                let tempMax = "#maxVal_" + obj.id;
                
                let percentage = parseFloat($(name).val());
                tempMin = parseFloat($(tempMin).text().split(' ').join(''));
                tempMax = parseFloat($(tempMax).text().split(' ').join(''));
                let tempValue = tempMin + percentage * (tempMax - tempMin) / 100;
                
                
                sliderValue["data"][(name.split("#")[1]).split("_").join(" ")] = tempValue;
            }
        });

        console.log(sliderValue);

        $.ajax({
            type: "POST",
            url: "updateProductsQuery/ProductSummary",
            data: sliderValue,
            success: (result) => {
                $(".productsDisplay").html(result);
            },
            error: (e) => {
                console.log(e);
            }

        })
    });

    //$("#CategoryId").addClass("dropdownCat");
    $("#CategoryId option").addClass("white");
    var catId;
    var subCatID;
    $("#CategoryId").change(function () {
        catId = $(this).val();
        debugger
        $.ajax({
            type: "POST",
            url: "/Search/GetSubCategoryList?categoryId=" + catId,
            contentType: "html",
            success: function (response) {
                debugger
                console.log("Run")
                $("#SubCategoryID").empty();
                $("#SubCategoryID").append(response);

            },
            error: function (err) {
                console.log(err);
            }
        });
    });

    $("#SubCategoryID").change(function () {
        subCatID = $(this).val();
    });


});