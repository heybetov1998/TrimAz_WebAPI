import Card from "../components/UI/Card";
import FilterSearch from "../components/UI/Filters/FilterSearch";
import Column from "../components/UI/grid/Column";
import Row from "../components/UI/grid/Row";
import PopularPosts from "../components/UI/PopularPosts";

const DUMMY_BLOGS = [
    {
        id: "b1",
        title: "This is blog title",
        image: {
            src: require("../assets/images/612-500x500.jpg"),
            alt: "Booking alt",
        },
        author: {
            id:'aut1',
            name: "Adil Heybetov",
            image: {
                src: require("../assets/images/555-500x500.jpg"),
                alt: "Author image",
            },
        },
        description:
            "This is lorem text description for blog of our community and society is sucks bro lorem text ipsum jest express and dolor sit amet with us coming it to the cinema salon",
    },
    {
        id: "b2",
        title: "This is blog title",
        image: {
            src: require("../assets/images/612-500x500.jpg"),
            alt: "Booking alt",
        },
        author: {
            id:'aut1',
            name: "Adil Heybetov",
            image: {
                src: require("../assets/images/555-500x500.jpg"),
                alt: "Author image",
            },
        },
        description:
            "This is lorem text description for blog of our community and society is sucks bro",
    },
    {
        id: "b3",
        title: "This is blog title",
        image: {
            src: require("../assets/images/612-500x500.jpg"),
            alt: "Booking alt",
        },
        author: {
            id:'aut1',
            name: "Adil Heybetov",
            image: {
                src: require("../assets/images/555-500x500.jpg"),
                alt: "Author image",
            },
        },
        description:
            "This is lorem text description for blog of our community and society is sucks bro",
    },
    {
        id: "b4",
        title: "This is blog title",
        image: {
            src: require("../assets/images/612-500x500.jpg"),
            alt: "Booking alt",
        },
        author: {
            id:'aut1',
            name: "Adil Heybetov",
            image: {
                src: require("../assets/images/555-500x500.jpg"),
                alt: "Author image",
            },
        },
        description:
            "This is lorem text description for blog of our community and society is sucks bro",
    },
];

const DUMMY_POSTS = [
    {
        id: "b1",
        title: "This is blog title",
        image: {
            src: require("../assets/images/612-500x500.jpg"),
            alt: "Booking alt",
        },
        createdDate: `${new Date().getUTCDate()}.${
            new Date().getMonth() + 1
        }.${new Date().getFullYear()}`,
    },
    {
        id: "b2",
        title: "This is blog title",
        image: {
            src: require("../assets/images/612-500x500.jpg"),
            alt: "Booking alt",
        },
        createdDate: `${new Date().getUTCDate()}.${
            new Date().getMonth() + 1
        }.${new Date().getFullYear()}`,
    },
    {
        id: "b3",
        title: "This is blog title",
        image: {
            src: require("../assets/images/612-500x500.jpg"),
            alt: "Booking alt",
        },
        createdDate: `${new Date().getUTCDate()}.${
            new Date().getMonth() + 1
        }.${new Date().getFullYear()}`,
    },
    {
        id: "b4",
        title: "This is blog title",
        image: {
            src: require("../assets/images/612-500x500.jpg"),
            alt: "Booking alt",
        },
        createdDate: `${new Date().getUTCDate()}.${
            new Date().getMonth() + 1
        }.${new Date().getFullYear()}`,
    },
];

const Blogs = () => {
    const day = new Date().getDate();
    const month = new Date().toLocaleString("en-US", { month: "long" });
    const year = new Date().getFullYear();

    const dateString = `${month} ${day}, ${year}`;

    return (
        <section id="blogs">
            <div className="container">
                <Row>
                    <Column className="order-1 order-md-0" md={6} lg={8} xl={8}>
                        <Row>
                            {DUMMY_BLOGS.map((blog) => (
                                <Column
                                    key={blog.id}
                                    className="mb-4"
                                    lg={6}
                                    xl={6}
                                >
                                    <Card
                                        goto={`/blogs/${blog.id}`}
                                        image={{
                                            src: blog.image.src,
                                            alt: blog.image.alt,
                                        }}
                                        title={blog.title}
                                        author={{
                                            id:blog.author.id,
                                            image: {
                                                src: blog.author.image.src,
                                                alt: blog.author.image.alt,
                                            },
                                            name: blog.author.name,
                                        }}
                                        description={blog.description}
                                        createdDate={dateString}
                                    />
                                </Column>
                            ))}
                        </Row>
                    </Column>
                    <Column className="order-0 order-md-1" md={6} lg={4} xl={4}>
                        <FilterSearch />
                        <PopularPosts posts={DUMMY_POSTS} />
                    </Column>
                </Row>
            </div>
        </section>
    );
};

export default Blogs;
