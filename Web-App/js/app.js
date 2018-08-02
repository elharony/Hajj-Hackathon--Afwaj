/* Map */
let map;

// Groups Locations
const groups = [
    {
        name: 'Egypt Group',
        id: '1',
        responsible: 'Mohamed Mously',
        phone: '011 55 139 251',
        company: 'Nayef For Travel',
        lating: {lat: 21.4225054, lng: 39.8259356},
        status: 'warning',
        members: {current: 120, total: 125}
    },
    {
        name: 'Malaysia Group',
        id: '2',
        responsible: 'Yahya Elharony',
        phone: '012 34 567 809',
        company: 'Remas Travels',
        lating: {lat: 21.4220051, lng: 39.8232086},
        status: 'safe',
        members: {current: 190, total: 190}
    },
    {
        name: 'India Group',
        id: '3',
        responsible: 'Moamen Mohamed',
        phone: '012 75 567 809',
        company: 'Remas Travels',
        lating: {lat: 21.4185168, lng: 39.8248074},
        status: 'danger',
        members: {current: 160, total: 200}
    },
    {
        name: 'Egypt Group',
        id: '4',
        responsible: 'Mohamed Mously',
        phone: '011 55 139 251',
        company: 'Nayef For Travel',
        lating: {lat: 21.419328, lng: 39.828872},
        status: 'warning',
        members: {current: 120, total: 125}
    },
    {
        name: 'Malaysia Group',
        id: '5',
        responsible: 'Yahya Elharony',
        phone: '012 34 567 809',
        company: 'Remas Travels',
        lating: {lat: 21.419904, lng: 39.823520},
        status: 'safe',
        members: {current: 190, total: 190}
    },
    {
        name: 'India Group',
        id: '6',
        responsible: 'Moamen Mohamed',
        phone: '012 75 567 809',
        company: 'Remas Travels',
        lating: {lat: 21.420923, lng: 39.825205},
        status: 'danger',
        members: {current: 160, total: 200}
    },
    {
        name: 'Egypt Group',
        id: '7',
        responsible: 'Mohamed Mously',
        phone: '011 55 139 251',
        company: 'Nayef For Travel',
        lating: {lat: 21.422905, lng: 39.822147},
        status: 'warning',
        members: {current: 120, total: 125}
    },
    {
        name: 'Malaysia Group',
        id: '8',
        responsible: 'Yahya Elharony',
        phone: '012 34 567 809',
        company: 'Remas Travels',
        lating: {lat: 21.425996, lng: 39.824606},
        status: 'safe',
        members: {current: 190, total: 190}
    },
    {
        name: 'India Group',
        id: '9',
        responsible: 'Moamen Mohamed',
        phone: '012 75 567 809',
        company: 'Remas Travels',
        lating: {lat: 21.424547, lng: 39.827719},
        status: 'danger',
        members: {current: 160, total: 200}
    },
    {
        name: 'Egypt Group',
        id: '10',
        responsible: 'Mohamed Mously',
        phone: '011 55 139 251',
        company: 'Nayef For Travel',
        lating: {lat: 21.423593, lng: 39.825103},
        status: 'warning',
        members: {current: 120, total: 125}
    },
    {
        name: 'Malaysia Group',
        id: '11',
        responsible: 'Yahya Elharony',
        phone: '012 34 567 809',
        company: 'Remas Travels',
        lating: {lat: 21.423992, lng: 39.828107},
        status: 'safe',
        members: {current: 190, total: 190}
    },
    {
        name: 'India Group',
        id: '12',
        responsible: 'Moamen Mohamed',
        phone: '012 75 567 809',
        company: 'Remas Travels',
        lating: {lat: 21.422254, lng: 39.830017},
        status: 'danger',
        members: {current: 160, total: 200}
    },
    {
        name: 'Egypt Group',
        id: '13',
        responsible: 'Mohamed Mously',
        phone: '011 55 139 251',
        company: 'Nayef For Travel',
        lating: {lat: 21.422956, lng: 39.822315},
        status: 'warning',
        members: {current: 120, total: 125}
    },
    {
        name: 'Malaysia Group',
        id: '14',
        responsible: 'Yahya Elharony',
        phone: '012 34 567 809',
        company: 'Remas Travels',
        lating: {lat: 21.423720, lng: 39.822831},
        status: 'safe',
        members: {current: 190, total: 190}
    },
    {
        name: 'India Group',
        id: '15',
        responsible: 'Moamen Mohamed',
        phone: '012 75 567 809',
        company: 'Remas Travels',
        lating: {lat: 21.424479, lng: 39.824719},
        status: 'danger',
        members: {current: 160, total: 200}
    },
]

// Map Configurations
const mapConfig = {
    lating: {lat: 21.422039, lng: 39.825467},
    zoom: 16,
    indicators: {
        safe: {color: '#32CD32', border: '#008000'},
        warning: {color: '#B59A34', border: '#ffdc33'},
        danger: {color: '#AF393C', border: '#D40005'}
    },
    styles: [
        {
            featureType: "poi",
            elementType: "labels",
            stylers: [
                  { visibility: "off" }
            ]
        }
    ]
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
            animation: google.maps.Animation.DROP,
            icon: `./img/marker-${group.status}.png`
        })

        // Click Event to each Marker
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







/******* Trips *******/

// Trips [ Data ]
const trips = [
    {
        trip: { 
            id: 1,
            from: 'Makkah',
            to: 'Muzdalifah',
            date: '2-8-2018',
        },
        group: {
            name: 'EGY-439',
            pilgrims: 200,
            statusCondition: 'success',
            statusText: 'Ongoing',
            liveData: {
                safe: 200,
                warning: 0,
                danger: 0
            }
        }
    },
    {
        trip: { 
            id: 2,
            from: 'Madinah',
            to: 'Arafat',
            date: '3-8-2018',
        },
        group: {
            name: 'PAK-129',
            pilgrims: 120,
            statusCondition: 'success',
            statusText: 'Ongoing',
            liveData: {
                safe: 118,
                warning: 0,
                danger: 2
            }
        }
    },
    {
        trip: { 
            id: 3,
            from: 'Safa W Marwa',
            to: 'Madinah',
            date: '4-8-2018',
        },
        group: {
            name: 'IND-20',
            pilgrims: 40,
            statusCondition: 'warning',
            statusText: 'Pending',
            liveData: {
                safe: 0,
                warning: 0,
                danger: 0
            }
        }
    },
    {
        trip: { 
            id: 4,
            from: 'Madinah',
            to: 'Makkah',
            date: '6-8-2018',
        },
        group: {
            name: 'EGY-98',
            pilgrims: 55,
            statusCondition: 'success',
            statusText: 'Ongoing',
            liveData: {
                safe: 54,
                warning: 1,
                danger: 0
            }
        }
    }
]

// Trips [ Update the UI ]
const tripsTable = document.querySelector(".trips-table")

trips.map((thisTrip) => {
    let row = document.createElement("tr")
    row.innerHTML = `
                        <td>${thisTrip.trip.id}</td>
                        <td>${thisTrip.trip.from}</td>
                        <td>${thisTrip.trip.to}</td>
                        <td>${thisTrip.trip.date}</td>
                        <td>${thisTrip.group.name}</td>
                        <td>${thisTrip.group.pilgrims}</td>
                        <td><span class="notification notification-${thisTrip.group.statusCondition}">${thisTrip.group.statusText}</span></td>
                        <td>
                            <span class="${thisTrip.group.liveData.safe > 0 ? 'notification notification-success' : 'notification'}">${thisTrip.group.liveData.safe}</span>
                            <span class="${thisTrip.group.liveData.warning > 0 ? 'notification notification-warning' : 'notification'}">${thisTrip.group.liveData.warning}</span>
                            <span class="${thisTrip.group.liveData.danger > 0 ? 'notification notification-danger' : 'notification'}">${thisTrip.group.liveData.danger}</span>
                        </td>
                        <td>
                            <button type="button" class="option btn btn-default" data-toggle="modal" data-target="#modal-${thisTrip.trip.id}">
                                <i class="material-icons">create</i>
                            </button>
                        </td>
                        <div class="modal fade" id="modal-${thisTrip.trip.id}" tabindex="-1" role="dialog" aria-labelledby="modal-${thisTrip.trip.id}" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="modal-${thisTrip.trip.id}">Assign A Trip Guide</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="bmd-label-floating">Hajj Group</label>
                                                <input type="text" class="form-control" value="${thisTrip.group.name}" disabled>
                                            </div>
                                            </div>
                                            <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="bmd-label-floating text-left">Group Guide</label>
                                                <select class="form-control">
                                                    <option value="Mohamed Mously">Mohamed Mously</option>
                                                    <option value="Yahya Elharony">Yahya Elharony</option>
                                                </select>
                                            </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                        <button type="button" class="btn btn-success" data-dismiss="modal">Save changes</button>
                                    </div>
                                </div>
                            </div>
                        </div>


                    `

    tripsTable.appendChild(row)
})