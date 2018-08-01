/* Map */
let map;

// Groups Locations
const groups = [
    {
        name: 'Egypt Group',
        id: '135',
        responsible: 'Mohamed Mously',
        phone: '011 55 139 251',
        company: 'Nayef For Travel',
        lating: {lat: 21.4225054, lng: 39.8259356},
        status: 'warning',
        members: {current: 120, total: 125}
    },
    {
        name: 'Malaysia Group',
        id: '257',
        responsible: 'Yahya Elharony',
        phone: '012 34 567 809',
        company: 'Remas Travels',
        lating: {lat: 21.4220051, lng: 39.8232086},
        status: 'safe',
        members: {current: 190, total: 190}
    },
    {
        name: 'India Group',
        id: '42',
        responsible: 'Moamen Mohamed',
        phone: '012 75 567 809',
        company: 'Remas Travels',
        lating: {lat: 21.4185168, lng: 39.8248074},
        status: 'danger',
        members: {current: 160, total: 200}
    },
]

// Map Configurations
const mapConfig = {
    lating: {lat: 21.421, lng: 39.818},
    zoom: 15,
    indicators: {
        safe: {color: '#32CD32', border: '#008000'},
        warning: {color: '#B59A34', border: '#ffdc33'},
        danger: {color: '#AF393C', border: '#D40005'}
    }
}

// Initialize Map
initMap = () => {
    const map = new google.maps.Map(document.getElementById('map'), {
        zoom: mapConfig.zoom,
        center: mapConfig.lating,
        mapTypeId: 'terrain',
        styles: mapConfig.styles
    })

    // InfoWindow Instance
    let infowindow = new google.maps.InfoWindow()

    // Display All Markers
    groups.map((group) => {

        // Marker Instance
        let marker = new google.maps.Marker({
            position: group.lating,
            map: map,
            icon: `./img/marker-${group.status}.png`
        })

        // Display An InfoWindow for each Marker
        google.maps.event.addListener(marker, 'click', () => {

            // InfoWindow Content
            let content = `<div class='infowindow'>
                <h2 class='title'>${group.name}</h2>
                <ul class='info'>
                    <li><i class="fas fa-hashtag fa-fw"></i> Group ID: ${group.id}</li>
                    <li><i class="fas fa-users fa-fw"></i> Members: ${group.members.current}/${group.members.total}</li>
                    <li><i class="fas fa-user-tie fa-fw"></i> Responsible: ${group.responsible}</li>
                    <li><i class="fas fa-mobile fa-fw"></i> Phone: ${group.phone}</li>
                    <li><i class="fas fa-building fa-fw"></i> Company: ${group.company}</li>
                </ul>
                <ul class='lost-members'>
                </ul>
            </div>`

            // Set the content
            infowindow.setContent(content)

            // Open the InfoWindow on Click
            infowindow.open(map, marker)
        })
    })
}