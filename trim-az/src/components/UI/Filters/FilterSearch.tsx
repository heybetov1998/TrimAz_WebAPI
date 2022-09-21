import CardFrame from "../CardFrame";
import SearchButton from "../Buttons/SearchButton";

const FilterSearch = () => {
    return (
        <CardFrame title="Search">
            <form action="">
                <div className="filter_search position-relative">
                    <input
                        className="search_input w-100"
                        placeholder="Search..."
                    />
                    <SearchButton />
                </div>
            </form>
        </CardFrame>
    );
};

export default FilterSearch;
