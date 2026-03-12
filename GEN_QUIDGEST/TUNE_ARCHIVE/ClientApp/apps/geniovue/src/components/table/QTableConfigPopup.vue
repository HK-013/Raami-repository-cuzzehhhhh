<template>
	<teleport :to="`#q-modal-${modalId}-body`">
		<q-tabs
			id="q-table-config__tabs"
			:selected-tab="selectedTab"
			:tabs-list="tabsList"
			@tab-changed="changeTab">
			<template
				v-for="configTab in tabsList"
				:key="configTab.id + configTab.key">
				<section
					v-if="configTab.isVisible"
					v-show="selectedTab === configTab.id"
					:id="configTab.component">
					<component
						:is="configTab.component"
						v-bind="configTab.props"
						v-on="configTab.handlers" />
				</section>
			</template>
		</q-tabs>
	</teleport>

	<teleport :to="`#q-modal-${modalId}-footer`">
		<q-row
			class="q-table-config__actions"
			:gutter="0">
			<q-col cols="auto">
				<q-button
					id="apply-config-btn"
					variant="bold"
					:label="tableCtrl.texts.applyText"
					:title="tableCtrl.texts.applyText"
					@click="applyConfig">
					<q-icon icon="apply" />
				</q-button>
			</q-col>

			<q-col cols="auto">
				<q-button
					id="cancel-config-btn"
					:label="tableCtrl.texts.cancelText"
					:title="tableCtrl.texts.cancelText"
					@click="hideConfig">
					<q-icon icon="cancel" />
				</q-button>
			</q-col>
		</q-row>
	</teleport>
</template>

<script>
	import { defineAsyncComponent } from 'vue'

	import QTabs from '@/components/containers/TabContainer.vue'

	export default {
		name: 'QTableConfigPopup',

		emits: [
			'apply',
			'hide',
			'show-view',
			'update:config',
			'update:views'
		],

		components: {
			QTabs,
			QTableConfigColumns: defineAsyncComponent(() => import('./QTableConfigColumns.vue')),
			QTableConfigFilters: defineAsyncComponent(() => import('./QTableConfigFilters.vue')),
			QTableConfigViews: defineAsyncComponent(() => import('./QTableConfigViews.vue'))
		},

		inheritAttrs: false,

		props: {
			/**
			 * The currently selected tab.
			 */
			tab: String,

			/**
			 * The identifier for the modal container where the configuration component is rendered.
			 */
			modalId: {
				type: String,
				required: true
			},

			/**
			 * The control object containing configuration details and state for the table.
			 * Used for managing properties such as column configuration and filters.
			 */
			tableCtrl: {
				type: Object,
				required: true
			},

			/**
			 * The unapplied user configuration data.
			 */
			configData: {
				type: Object,
				default: () => ({})
			}
		},

		expose: [],

		data()
		{
			return {
				selectedTab: 'columns'
			}
		},

		mounted()
		{
			// When the popup opens, focus on the selected tab.
			document.querySelector(`#q-modal-${this.modalId} [aria-controls="${this.selectedTab}"]`)?.focus()

			document.addEventListener('keydown', this.handleKeyPress)
		},

		beforeUnmount()
		{
			document.removeEventListener('keydown', this.handleKeyPress)
		},

		computed: {
			tabsList()
			{
				return [
					{
						id: 'views',
						key: '',
						component: 'q-table-config-views',
						icon: { icon: 'view-manager' },
						label: this.tableCtrl.texts.viewManagerText,
						isVisible: this.tableCtrl.config.configOptions.find((op) => op.id === 'views')?.visible ?? false,
						props: {
							configNames: this.tableCtrl.config.tableConfigNames,
							configDefaultName: this.tableCtrl.config.defaultTableConfigName,
							configCurrentName: this.tableCtrl.config.userTableConfigName,
							texts: this.tableCtrl.texts
						},
						handlers: {
							showView: (eventData) => this.showView(eventData),
							'update:views': (eventData) => this.updateViews(eventData)
						}
					},
					{
						id: 'columns',
						key: this.tableCtrl.config.userTableConfigName,
						component: 'q-table-config-columns',
						icon: { icon: 'list' },
						label: this.tableCtrl.texts.columns,
						isVisible: this.tableCtrl.config.configOptions.find((op) => op.id === 'columns')?.visible ?? false,
						props: {
							tableName: this.tableCtrl.config.name,
							columns: this.configData.columns ?? this.tableCtrl.columns,
							filters: this.configData.filters ?? this.tableCtrl.filters,
							texts: this.tableCtrl.texts,
							defaultSearchColumnName: this.configData.defaultSearchColumn ?? this.tableCtrl.config.defaultSearchColumnName,
							hasTextWrap: this.configData.textWrap ?? this.tableCtrl.config.hasTextWrap,
							resourcesPath: this.tableCtrl.config.resourcesPath
						},
						handlers: {
							reset: () => this.resetColumnConfig(),
							'update:columns': (eventData) => this.updateColumnConfig(eventData),
							toggleTextWrap: () => this.toggleTextWrap()
						}
					},
					{
						id: 'filters',
						key: this.tableCtrl.config.userTableConfigName,
						component: 'q-table-config-filters',
						icon: { icon: 'filter' },
						label: this.tableCtrl.texts.filtersText,
						isVisible: this.tableCtrl.config.configOptions.find((op) => op.id === 'filters')?.visible ?? false,
						props: {
							tableName: this.tableCtrl.config.name,
							columns: this.configData.columns ?? this.tableCtrl.columns,
							selectedColumn: this.tableCtrl.selectedConfigColumn,
							selectedFilter: this.tableCtrl.selectedConfigFilter,
							dateFormats: this.tableCtrl.config.dateFormats,
							activeFilters: this.configData.activeFilters ?? this.tableCtrl.activeFilters,
							groupFilters: this.configData.groupFilters ?? this.tableCtrl.groupFilters,
							filters: this.configData.filters ?? this.tableCtrl.filters,
							texts: this.tableCtrl.texts,
							locale: this.tableCtrl.locale,
							filterOperators: this.tableCtrl.filterOperators
						},
						handlers: {
							'update:filters': (eventData) => this.updateFilters(eventData),
							'update:activeFilters': (eventData) => this.updateActiveFilters(eventData),
							'update:groupFilters': (eventData) => this.updateGroupFilters(eventData)
						}
					}
				]
			}
		},

		methods: {
			/**
			 * Emits the event to hide the configuration popup.
			 */
			hideConfig()
			{
				this.$emit('hide')
			},

			/**
			 * Emits the event to apply the changes to the user configuration.
			 */
			applyConfig()
			{
				this.$emit('apply')
			},

			/**
			 * Handles the keydown event.
			 * @param {Event} event The keydown event object
			 */
			handleKeyPress(event)
			{
				const filtersTab = document.getElementById('q-table-config-filters')

				// Submit the current configuration if the 'Enter' key is pressed on a filter.
				// Prevent submission if enter was pressed on a button, to avoid submitting
				// when the user is just trying to add or remove a filter, for example.
				if (event.key === 'Enter' && !event.target.matches('button') && filtersTab.contains(event.target))
					this.applyConfig()
			},

			/**
			 * Switches to the specified tab.
			 * @param {string} selectedTab The desired tab
			 */
			changeTab(selectedTab)
			{
				const tab = this.tabsList.find((t) => t.id === selectedTab)
				if (!tab.isVisible)
					selectedTab = this.tabsList.find((t) => t.isVisible)?.id
				this.selectedTab = selectedTab
			},

			/**
			 * Toggles the text wrap.
			 */
			toggleTextWrap()
			{
				const config = { ...this.configData }
				config.textWrap = typeof this.configData.textWrap !== 'undefined'
					? !this.configData.textWrap
					: !this.tableCtrl.config.hasTextWrap
				this.$emit('update:config', config)
			},

			/**
			 * Updates the column configuration.
			 * @param {object} colConfig The new column configuration
			 */
			updateColumnConfig(colConfig)
			{
				const config = { ...this.configData }
				config.columns = colConfig.columns
				config.defaultSearchColumn = colConfig.defaultSearchColumn

				// If there are changes to the filters, overwites them.
				if (colConfig.filters !== null)
					config.filters = colConfig.filters

				this.$emit('update:config', config)
			},

			/**
			 * Resets the column configuration.
			 */
			resetColumnConfig()
			{
				const config = { ...this.configData }
				config.columns = this.tableCtrl.columnsOriginal
				config.defaultSearchColumn = this.tableCtrl.config.defaultSearchColumnNameOriginal
				this.$emit('update:config', config)
			},

			/**
			 * Updates the list of applied filters.
			 * @param {array} filters The filters
			 */
			updateFilters(filters)
			{
				this.$emit('update:config', { ...this.configData, filters })
			},

			/**
			 * Updates the active filters.
			 * @param {object} activeFilters The active filters
			 */
			updateActiveFilters(activeFilters)
			{
				this.$emit('update:config', { ...this.configData, activeFilters })
			},

			/**
			 * Updates the list of group filters.
			 * @param {array} groupFilters The group filters
			 */
			updateGroupFilters(groupFilters)
			{
				this.$emit('update:config', { ...this.configData, groupFilters })
			},

			/**
			 * Updates the user configuration views.
			 * @param {array} views The configuration views
			 */
			updateViews(views)
			{
				this.$emit('update:views', views)
			},

			/**
			 * Emits the event to preview the specified configuration view.
			 * @param {number} id The identifier of the view
			 */
			showView(id)
			{
				this.$emit('show-view', id)
			}
		},

		watch: {
			tab: {
				handler(val)
				{
					this.changeTab(val)
				},
				immediate: true
			}
		}
	}
</script>
