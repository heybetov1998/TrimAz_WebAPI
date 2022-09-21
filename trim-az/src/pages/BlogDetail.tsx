import AuthorInfo from "../components/UI/Author/AuthorInfo";
import FilterSearch from "../components/UI/Filters/FilterSearch";
import Column from "../components/UI/grid/Column";
import Row from "../components/UI/grid/Row";
import PopularPosts from "../components/UI/PopularPosts";

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

const DUMMY_AUTHOR = {
    id: "auth1",
    name: "Aliashraf Merdanov",
    image: {
        src: require("../assets/images/555-500x500.jpg"),
        alt: "qariban bir author",
    },
};

const BlogDetail = () => (
    <section id="blogs">
        <div className="container">
            <Row>
                <Column
                    className="blog_part order-1 order-md-0"
                    md={6}
                    lg={8}
                    xl={8}
                >
                    <div className="main_image">
                        <img
                            src={require("../assets/images/intro.jpg")}
                            alt="some alt text"
                        />
                    </div>
                    <div className="blog_info">
                        <h2 className="blog_title">This is blog title</h2>
                        <AuthorInfo
                            className="blog_author"
                            author={DUMMY_AUTHOR}
                            createdDate="September 1, 2003"
                        />
                    </div>
                    <div className="blog_content">
                        <p>
                            Lorem ipsum dolor sit amet consectetur adipisicing
                            elit. Ducimus placeat enim, labore recusandae quod
                            quae laborum amet nesciunt ipsa dolores eaque rerum
                            nisi vitae aperiam, veniam iste a, libero provident.
                            Iure quas quisquam reprehenderit nam laudantium
                            omnis cumque beatae optio sunt, aut hic vel, quis
                            minus, error consequuntur ratione corrupti
                            voluptates! Debitis magnam, labore necessitatibus
                            odit maxime laborum? Architecto illo optio hic,
                            quisquam ab officia vitae aliquid nobis explicabo
                            iure sunt sint atque veniam ullam amet repellendus
                            ratione. Cumque eaque incidunt fugit delectus quas
                            in, recusandae quasi alias laudantium voluptates
                            excepturi repellendus. Animi nulla cumque libero
                            enim corrupti laborum minus quia aut harum!
                            Excepturi, esse quibusdam cum corrupti et nam eaque,
                            voluptatibus laboriosam quis hic, eveniet sapiente
                            enim quia nostrum dicta ducimus. Nihil adipisci,
                            veniam rerum labore sequi dolores illo a, iusto
                            dolorum, nam ad. Aliquid omnis ea qui, quos
                            provident voluptas! Maiores eum ratione ex
                            doloremque odit quisquam laboriosam odio! Distinctio
                            magnam officia dolorum vitae, optio, asperiores,
                            nulla nisi at libero fugit iusto quasi quod. Ducimus
                            non obcaecati vero harum dolorum, dolorem, ipsam,
                            pariatur assumenda quaerat hic perspiciatis eveniet.
                            Iusto, reprehenderit. Saepe facere fuga recusandae
                            minima! Sapiente totam voluptate aut, fugit nobis
                            officia veniam quaerat ducimus facere ipsam dolore
                            magni, quam quidem minima iure ad vel cumque
                            voluptas quod officiis eligendi odio. Praesentium
                            voluptate reprehenderit atque nostrum. Possimus non
                            eos quia molestiae ad unde quo repellat dolorem ut
                            mollitia illo totam similique cumque, nulla
                            exercitationem sit. Cupiditate provident quasi
                            numquam, tempora et illum obcaecati quod. Mollitia
                            saepe reprehenderit cupiditate, perspiciatis et fuga
                            consectetur deleniti maiores vitae eum accusamus
                            obcaecati tempore ducimus fugit ullam animi cumque
                            sed, repudiandae eos commodi? Quisquam cupiditate
                            quibusdam deserunt, dolorem, ratione vero pariatur
                            eum eveniet veniam ab illo tempora facere adipisci
                            vitae quam et deleniti sunt corporis! Doloribus
                            facere modi eaque dolorem totam nisi ipsum vitae
                            accusamus illo officia ducimus magni iusto vel quos
                            nulla quae maxime eligendi tempore, at provident
                            assumenda. Harum quasi aut nemo rem temporibus
                            laboriosam magni exercitationem odio, beatae
                            consectetur aspernatur ipsam excepturi nam libero
                            praesentium amet voluptate consequuntur officiis,
                            ullam modi quos. In, consequatur? Possimus accusamus
                            soluta veritatis nihil veniam sed at numquam atque
                            debitis placeat, accusantium incidunt reprehenderit
                            voluptatem non dignissimos optio eveniet assumenda
                            animi quasi nam porro? Et iste laborum ab? Ab ullam
                            a totam nesciunt, cumque possimus impedit, aut neque
                            consequuntur explicabo ad tempora dignissimos
                            tempore qui autem ut perferendis iste, repellendus
                            fuga beatae? Velit sequi eveniet corrupti laborum
                            reiciendis voluptatum minus consequuntur facere odit
                            nam earum, molestias perferendis quidem alias eaque
                            laboriosam dicta voluptas non architecto quod! A
                            ipsum optio soluta animi excepturi, alias nostrum
                            harum, fugiat quidem nihil laudantium aut corporis
                            explicabo praesentium perspiciatis libero recusandae
                            dolorem ad quos non vitae sit architecto facilis
                            eius. Aperiam vel corporis optio iure cupiditate
                            autem, facilis eveniet dolor quo quasi provident
                            porro dolorem esse aliquam, deserunt totam
                            consequatur at ad sapiente amet vero quae, magni
                            temporibus adipisci? At, quibusdam! Optio aspernatur
                            quia ex, dicta doloribus ad id placeat illum odio
                            unde delectus pariatur ipsam ipsa error quis
                            possimus?
                        </p>
                    </div>
                </Column>
                <Column className="order-0 order-md-1" md={6} lg={4} xl={4}>
                    <FilterSearch />
                    <PopularPosts posts={DUMMY_POSTS} />
                </Column>
            </Row>
        </div>
    </section>
);

export default BlogDetail;
