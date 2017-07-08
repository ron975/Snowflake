import React from 'react'
import { Route, Link } from 'react-router-dom'
import withActions from 'snowflake/compose/withActions'
import compose from 'recompose/compose'
import _ from 'lodash'
import SidebarVisibleView from 'components/views/SidebarVisibleView'
import PlatformListView from 'components/views/PlatformListView'
import withQueryState from 'snowflake/compose/withQueryState'
import GameListView from 'components/views/GameListView'

const PlatformRendererTest = compose(withQueryState)(({platforms, queryState}) => (
  <PlatformListView platforms={ platforms }
    platform={ queryState.platform }
    gameCount={ queryState.platformGames ? queryState.platformGames.length : 0 }/>
))

const GameRendererTest = compose(withQueryState)(({games, queryState}) => (
  <GameListView games={queryState.platformGames}
    platform={queryState.platform}/>
))

const GameViewRenderTest = withQueryState(({queryState}) => (
  <div>
    { queryState.game.Title }
  </div>
))

class Switchboard extends React.Component {
  componentDidMount () {
    this.props.actions.platforms.beginRefreshPlatforms()
    this.props.actions.games.beginRefreshGames()
  }

  render () {
    return (
      <div>
        <SidebarVisibleView>
          <Route path="/platforms/" component={PlatformRendererTest}/>
          <Route path="/games/" component={GameRendererTest}/>
          <Route path="/gamedetail/" component={GameViewRenderTest}/>
        </SidebarVisibleView>
      </div>
    )
  }
}
export default withActions(Switchboard)
