import { Link } from "react-router-dom";
import BarberCard from "../components/Cards/BarberCard";
import ResultBar from "../components/UI/Bars/ResultBar";
import FilterCheckbox from "../components/UI/Filters/FilterCheckbox";
import FilterPrice from "../components/UI/Filters/FilterPrice";
import FilterSearch from "../components/UI/Filters/FilterSearch";
import Column from "../components/UI/grid/Column";
import Row from "../components/UI/grid/Row";

const DUMMY_BARBERS = [
    {
        id: 1,
        name: "Balaeli Israfiloglu",
        image: {
            src: require("../assets/images/1077-500x500.jpg"),
            alt: "Barbershop image",
        },
        rating: 4.5,
    },
    {
        id: 2,
        name: "Balaeli Israfiloglu",
        image: {
            src: require("../assets/images/1077-500x500.jpg"),
            alt: "Barbershop image",
        },
        rating: 4.5,
    },
    {
        id: 3,
        name: "Balaeli Israfiloglu",
        image: {
            src: require("../assets/images/1077-500x500.jpg"),
            alt: "Barbershop image",
        },
        rating: 4.5,
    },
    {
        id: 4,
        name: "Balaeli Israfilogluad asdasdsdksdfl",
        image: {
            src: require("../assets/images/1077-500x500.jpg"),
            alt: "Barbershop image",
        },
        rating: 4.5,
    },
    {
        id: 5,
        name: "Balaeli Israfiloglu",
        image: {
            src: require("../assets/images/1077-500x500.jpg"),
            alt: "Barbershop image",
        },
        rating: 4.5,
    },
    {
        id: 6,
        name: "Balaeli Israfiloglu",
        image: {
            src: require("../assets/images/1077-500x500.jpg"),
            alt: "Barbershop image",
        },
        rating: 4.5,
    },
    {
        id: 7,
        name: "Balaeli Israfiloglu",
        image: {
            src: require("../assets/images/1077-500x500.jpg"),
            alt: "Barbershop image",
        },
        rating: 4.5,
    },
    {
        id: 8,
        name: "Balaeli Israfiloglu",
        image: {
            src: require("../assets/images/1077-500x500.jpg"),
            alt: "Barbershop image",
        },
        rating: 4.5,
    },
    {
        id: 9,
        name: "Balaeli Israfiloglu",
        image: {
            src: require("../assets/images/1077-500x500.jpg"),
            alt: "Barbershop image",
        },
        rating: 4.5,
    },
    {
        id: 10,
        name: "Balaeli Israfiloglu",
        image: {
            src: require("../assets/images/1077-500x500.jpg"),
            alt: "Barbershop image",
        },
        rating: 4.5,
    },
    {
        id: 11,
        name: "Balaeli Israfiloglu",
        image: {
            src: require("../assets/images/1077-500x500.jpg"),
            alt: "Barbershop image",
        },
        rating: 4.5,
    },
];

const checkboxes = {
    title: "Services",
    items: [
        { id: "ch1", text: "Saç qırxma" },
        { id: "ch2", text: "Saqqal qırxma" },
        { id: "ch3", text: "Maska qoyulması" },
        { id: "ch4", text: "Üz baxımı" },
        { id: "ch5", text: "Saç rənglənməsi" },
    ],
};

const Barbers = () => {
    return (
        <section id="market">
            <div className="container">
                <Row>
                    <Column md={4} lg={3} xl={3}>
                        <FilterSearch />
                        <FilterPrice />
                        <FilterCheckbox checkboxes={checkboxes} />
                    </Column>
                    <Column md={8} lg={9} xl={9}>
                        <ResultBar itemCount={24} />
                        <div className="results">
                            <Row>
                                {DUMMY_BARBERS.map((barber) => {
                                    return (
                                        <Column
                                            key={barber.id}
                                            className="mb-4"
                                            md={6}
                                            lg={6}
                                            xl={6}
                                        >
                                            <Link
                                                className="card_holder"
                                                to={`${barber.id}`}
                                            >
                                                <BarberCard barber={barber} />
                                            </Link>
                                        </Column>
                                    );
                                })}
                            </Row>
                        </div>
                    </Column>
                </Row>
            </div>
        </section>
    );
};

export default Barbers;
