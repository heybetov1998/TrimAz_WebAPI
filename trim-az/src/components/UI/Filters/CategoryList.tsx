type PropsType = {
    children: React.ReactNode;
    className?: string;
};

const CategoryList = (props: PropsType) => {
    return (
        <ul className={`category_list ${props.className ?? ""}`}>
            {props.children}
        </ul>
    );
};

export default CategoryList;
