import SubmitButton from "../Buttons/SubmitButton";
import CardFrame from "../CardFrame";
import PriceInput from "../Inputs/PriceInput";

const FilterPrice = () => {
    return (
        <CardFrame title={"Filter Price"}>
            <PriceInput id="minPrice" name="Min Price" />
            <PriceInput id="maxPrice" name="Max Price" />
            <SubmitButton text="Search" className="search_price"/>
        </CardFrame>
    );
};

export default FilterPrice;
