import Select from "react-select";
import { useState } from "react";
import DatePicker from "react-datepicker";
import SubmitButton from "../UI/Buttons/SubmitButton";
import Column from "../UI/grid/Column";
import Row from "../UI/grid/Row";

import image from "../../assets/images/intro.jpg";

import "react-datepicker/dist/react-datepicker.css";

// const options = [
//     { value: "test", label: "test" },
//     { value: "hello", label: "hello" },
// ];

interface ColorOption {
    readonly value: string;
    readonly label: string;
    readonly color: string;
    readonly isFixed?: boolean;
    readonly isDisabled?: boolean;
}

interface FlavorOption {
    readonly value: string;
    readonly label: string;
    readonly rating: string;
}

interface GroupedOption {
    readonly label: string;
    readonly options: readonly ColorOption[] | readonly FlavorOption[];
}

const colorList: ColorOption[] = [
    { value: "blue", label: "Blue", color: "blue" },
    { value: "red", label: "Red", color: "red" },
    { value: "yellow", label: "Yellow", color: "yellow" },
    { value: "green", label: "Green", color: "green" },
];

const flavorList: FlavorOption[] = [
    { value: "vanilla", label: "Vanilla", rating: "safe" },
    { value: "chocolate", label: "Chocolate", rating: "good" },
    { value: "strawberry", label: "Strawberry", rating: "wild" },
    { value: "salted-caramel", label: "Salted Caramel", rating: "crazy" },
];

const groupList: GroupedOption[] = [
    { label: "Colors", options: colorList },
    { label: "Flavors", options: flavorList },
];

const FormatGroupLabel = (group: GroupedOption) => {
    return (
        <div className="group_label">
            <span>{group.label} </span>
            <span className="group_badge">{group.options.length}</span>
        </div>
    );
};

const Intro = () => {
    const [reservationDate, setReservationDate] = useState(new Date());

    const reservationHandler = (date: Date) => {
        setReservationDate(date);
    };

    return (
        <section id="intro" style={{ backgroundImage: `url("${image}")` }}>
            <div className="section_backdrop">
                <div className="container h-100">
                    <div className="section_content">
                        <div className="text_part">
                            <h3>Find your style with us</h3>
                            <p>Get best barber in country just one click</p>
                        </div>
                        <div className="search_part w-100">
                            <form>
                                <Row>
                                    <Column
                                        className="mb-3 m-lg-0"
                                        lg={4}
                                        xl={4}
                                    >
                                        <Select<
                                            ColorOption | FlavorOption,
                                            true,
                                            GroupedOption
                                        >
                                            formatGroupLabel={FormatGroupLabel}
                                            className="service_selection"
                                            options={groupList}
                                            isMulti
                                        />
                                    </Column>
                                    <Column
                                        className="mb-3 m-lg-0"
                                        lg={4}
                                        xl={4}
                                    >
                                        {/* <input
                                            type="date"
                                            name="date"
                                            id="date"
                                            placeholder={"select"}
                                        /> */}
                                        <DatePicker
                                            selected={reservationDate}
                                            onChange={reservationHandler}
                                            className="no_transition"
                                        />
                                    </Column>
                                    <Column lg={4} xl={4}>
                                        <SubmitButton text="Search" />
                                    </Column>
                                </Row>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};
export default Intro;
