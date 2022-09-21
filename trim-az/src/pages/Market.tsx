import ResultBar from "../components/UI/Bars/ResultBar";
import Card from "../components/UI/Card";
import FilterCheckbox from "../components/UI/Filters/FilterCheckbox";
import FilterPrice from "../components/UI/Filters/FilterPrice";
import FilterSearch from "../components/UI/Filters/FilterSearch";
import Column from "../components/UI/grid/Column";
import Row from "../components/UI/grid/Row";

const filteredDUMMYProducts = [
    {
        id: 1,
        title: "HairCutter",
        price: 400,
        location: "Baku, Azerbaijan",
        afterPrice: null,
        image: {
            src: require("../assets/images/555-500x500.jpg"),
            alt: "Product image",
        },
        author: {
            id: "aut1",
            image: {
                src: require("../assets/images/555-500x500.jpg"),
                alt: "Author Image",
            },
            name: "Engin Altan",
            goto: `/users/enginAltan`,
        },
    },
    {
        id: 2,
        title: "Fen",
        price: 500,
        location: "Baku, Azerbaijan",
        afterPrice: null,
        image: {
            src: require("../assets/images/555-500x500.jpg"),
            alt: "Product image",
        },
        author: {
            id: "aut1",
            image: {
                src: require("../assets/images/555-500x500.jpg"),
                alt: "Author Image",
            },
            name: "Enner Valencia",
            goto: "/users/ennerValencia",
        },
    },
    {
        id: 3,
        title: "Qayçı",
        price: 20,
        location: "Baku, Azerbaijan",
        afterPrice: null,
        image: {
            src: require("../assets/images/555-500x500.jpg"),
            alt: "Product image",
        },
        author: {
            id: "aut1",
            image: {
                src: require("../assets/images/555-500x500.jpg"),
                alt: "Author Image",
            },
            name: "Altay Bayındır",
            goto: "/users/altayBayindir",
        },
    },
    {
        id: 4,
        title: "Saç ütüsü",
        price: 100,
        location: "Baku, Azerbaijan",
        afterPrice: null,
        image: {
            src: require("../assets/images/555-500x500.jpg"),
            alt: "Product image",
        },
        author: {
            id: "aut1",
            image: {
                src: require("../assets/images/555-500x500.jpg"),
                alt: "Author Image",
            },
            name: "Atilla Szalai",
            goto: "/users/atillaSzalai",
        },
    },
    {
        id: 5,
        title: "Termos",
        price: 80,
        location: "Yasamal, Baku",
        afterPrice: null,
        image: {
            src: require("../assets/images/555-500x500.jpg"),
            alt: "Product image",
        },
        author: {
            id: "aut1",
            image: {
                src: require("../assets/images/555-500x500.jpg"),
                alt: "Author Image",
            },
            name: "Serdar Dursun",
            goto: "/users/serdarDursun",
        },
    },
];

const checkboxes = {
    title: "Services",
    items: [
        { id: "ch1", text: "Ütü" },
        { id: "ch2", text: "Saçqırxan" },
        { id: "ch3", text: "Üzqırxan" },
        { id: "ch4", text: "Qayçı" },
        { id: "ch5", text: "Streçband" },
    ],
};

const Market = () => {
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
                        <ResultBar itemCount={12} />
                        <div className="results">
                            <Row>
                                {filteredDUMMYProducts.map((product) => {
                                    return (
                                        <Column
                                            key={product.id}
                                            className="mb-4"
                                            md={6}
                                            lg={4}
                                            xl={4}
                                        >
                                            <Card
                                                goto={`/market/products/${product.id}`}
                                                hasHeart
                                                title={product.title}
                                                price={product.price}
                                                image={product.image}
                                                author={{
                                                    id: product.author.id,
                                                    name: product.author.name,
                                                    image: product.author.image,
                                                }}
                                            />
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

export default Market;
