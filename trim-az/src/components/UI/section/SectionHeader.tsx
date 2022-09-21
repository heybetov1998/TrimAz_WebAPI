interface Props {
    text: string;
}

const SectionHeader = (props: Props) => {
    return <h2 className="section_header">{props.text}</h2>;
};

export default SectionHeader;
