type PropsType = {
    text: string;
    className?: string;
};

const SectionPartName = (props: PropsType) => {
    return (
        <h5 className={`section_part_name ${props.className ?? ""}`}>
            {props.text}
        </h5>
    );
};

export default SectionPartName;
