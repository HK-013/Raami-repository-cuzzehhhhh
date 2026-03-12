<template>
	<div class="q-action-list">
		<!-- INLINE -->
		<template
			v-for="(group, i) in groups.filter((g) => g.display === 'inline')"
			:key="group.id">
			<q-button-group
				v-bind="$attrs"
				:borderless="props.borderless"
				:disabled="group.disabled">
				<q-button
					v-for="action in getGroupActions(group.id)"
					:key="action.key"
					:title="action.label"
					:label="action.icon ? '' : action.label"
					:disabled="props.readonly || action.disabled"
					:size="group.size"
					:class="group.customClass"
					@click="() => onItemClick(action.key)">
					<q-icon
						v-if="action.icon"
						v-bind="action.icon" />
				</q-button>
			</q-button-group>
			<q-divider
				v-if="i < groups.length - 1"
				direction="vertical" />
		</template>

		<!-- DROPDOWN -->
		<!-- Groups with multiple items and display: 'dropdown' -->
		<template v-if="groups.some((g) => g.display === 'dropdown')">
			<q-button
				ref="activator"
				data-type="options-button"
				aria-haspopup="true"
				v-bind="$attrs"
				:borderless="props.borderless"
				:size="props.dropdownSize">
				<slot>
					<q-icon icon="more-items" />
				</slot>

				<q-icon
					v-if="!!$slots.default"
					class="q-action-list__expand"
					icon="expand" />
			</q-button>

			<q-dropdown-menu
				:activator="activatorRef?.$el"
				:items="filteredItems"
				:groups="groups.filter((g) => g.display === 'dropdown')"
				:icons="props.submenusIcon"
				:placement="props.placement"
				@select="onItemClick" />
		</template>
	</div>
</template>

<script setup lang="ts">
	// Utils
	import { computed, useTemplateRef } from 'vue'
	import { DEFAULT_SUBMENU_ICONS } from './constants'

	// Components
	import { QDropdownMenu, QButton } from '@quidgest/ui/components'

	// Types
	import type { QActionListGroup, QActionListItem, QActionListProps } from './types'

	const props = withDefaults(defineProps<QActionListProps>(), {
		dropdownSize: 'regular',
		placement: 'right-start',
		submenusIcon: () => DEFAULT_SUBMENU_ICONS
	})

	const emit = defineEmits<{
		(e: 'click', key: string): void
	}>()

	const activatorRef = useTemplateRef('activator')

	const filteredItems = computed<QActionListItem[]>(() => {
		return props.items?.filter((item: QActionListItem) => item.isVisible !== false) ?? []
	})

	const groups = computed<QActionListGroup[]>(() => {
		if (props.groups?.length) {
			// Ensure groups without items are not displayed.
			return props.groups
				.filter((group) => filteredItems.value?.some((item) => item.group === group.id))
				.map((group) => ({
					...group,
					display: group.display ?? 'dropdown'
				}))
		}

		// Generate a default group without title
		return [{ id: '', title: '', display: 'dropdown' }]
	})

	function getGroupActions(group?: string) {
		if (!group) {
			// If no group is specified, return all items
			return filteredItems.value
		}

		// Filter items by the specified group
		return filteredItems.value?.filter((item: QActionListItem) => item.group === group)
	}

	/**
	 * Handles the click event for a list action.
	 *
	 * @param actionKey - The key of the action that was clicked.
	 */
	function onItemClick(actionKey: string) {
		emit('click', actionKey)
	}

	defineOptions({
		inheritAttrs: false
	})
</script>
