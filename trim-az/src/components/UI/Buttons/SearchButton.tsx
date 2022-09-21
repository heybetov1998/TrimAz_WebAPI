import { BiSearch } from "react-icons/bi";

type PropsType = {
    className?: string;
    type?: "button" | "submit" | "reset" | undefined;
};

const SearchButton = (props: PropsType) => {
    return (
        <button
            type={props.type ?? "submit"}
            className={`search_button ${props.className ?? ""}`}
        >
            <BiSearch size={"1.2rem"} />
        </button>
    );
};

export default SearchButton;
