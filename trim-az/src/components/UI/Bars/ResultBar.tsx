type PropsType = {
    itemCount: number;
};

const ResultBar = (props: PropsType) => (
    <div className="resultsBar">
        <div className="leftBar d-flex align-items-center">
            <span>
                {props.itemCount !== 0 ? props.itemCount : "No"} items found
            </span>
            <button className="clear_filter">Clear filter</button>
        </div>
    </div>
);

export default ResultBar;
