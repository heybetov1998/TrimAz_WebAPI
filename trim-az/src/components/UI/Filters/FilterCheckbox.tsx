import CardFrame from "../CardFrame";
import CategoryItem from "./CategoryItem";
import CategoryList from "./CategoryList";

type ItemType = {
    id: string;
    text: string;
};

type PropsType = {
    checkboxes: { title: string; items: ItemType[] };
};

const FilterCheckbox = (props: PropsType) => {
    return (
        <CardFrame title={props.checkboxes.title}>
            <CategoryList>
                {props.checkboxes.items.map((item) => (
                    <CategoryItem key={item.id} text={item.text} />
                ))}
            </CategoryList>
        </CardFrame>
    );
};

export default FilterCheckbox;
