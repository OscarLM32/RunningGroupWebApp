

function Hero(){
    return (
        <section class="py-5 text-center container-fluid bg-dark text-light">
            <div class="row py-lg-5">
                <div class="col-lg-6 col-md-8 mx-auto">
                    <h1 class="fw-light">Welcome to RunTogether</h1>
                    <p class="lead text-secondary">
                        Discover a vibrant community of runners who share your passion. Whether you're a seasoned marathoner or just starting your journey, connect with groups near you, join events, and achieve your goals together.
                    </p>
                    <p>
                        <a href="/clubs" class="btn btn-primary my-2">Find a Running Club</a>
                        <a href="/events" class="btn btn-outline-light my-2">Explore Upcoming Events</a>
                    </p>
                </div>
            </div>
        </section>
    )
}

export default Hero;