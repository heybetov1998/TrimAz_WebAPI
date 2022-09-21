import StandartCheckbox from "../Checkboxes/StandartCheckbox";

type PropsType = {
    className?: string;
    text: string;
};

const CategoryItem = (props: PropsType) => {
    return (
        <li className={`category_item ${props.className ?? ""}`}>
            <StandartCheckbox text={props.text} />
        </li>
    );
};

export default CategoryItem;
